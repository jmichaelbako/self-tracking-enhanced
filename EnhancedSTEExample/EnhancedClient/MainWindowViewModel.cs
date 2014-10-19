using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.ComponentModel;
using EnhancedEntities;
using EnhancedClient.OrderService;
using System.Windows.Input;

namespace EnhancedClient
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<OrderHeader> _orders;
        public ObservableCollection<OrderHeader> Orders
        {
            get { return _orders ?? (_orders = new ObservableCollection<OrderHeader>()); }
            set
            {
                _orders = value;
                OnPropertyChanged("Orders");
            }

        }

        private OrderHeader _selectedOrder;
        public OrderHeader SelectedOrder
        {
            get { return _selectedOrder ?? (_selectedOrder = new OrderHeader()); }
            set
            {
                _selectedOrder = value;
                OnPropertyChanged("SelectedOrder");
            }
        }

        public MainWindowViewModel()
        {
            LoadOrders();
        }

        private void LoadOrders()
        {
            var client = new OrderServiceClient();

            Observable.FromAsyncPattern<List<OrderHeader>>(
                client.BeginGetOrders,
                client.EndGetOrders
            )()
            .ObserveOnDispatcher()
            .Subscribe(orders => orders.ForEach(Orders.Add));
        }

        public ICommand SaveOrder
        {
            get
            {
                return new RelayCommand(
                    obj =>
                    {
                        // grab a copy of the details
                        var details = SelectedOrder.OrderDetails.ToList();

                        // clean off the order object graph
                        SelectedOrder.CleanObjectGraph();

                        // reattach the details to the order
                        SelectedOrder.AttachOrderDetails(details);

                        // send the order to the service
                        var client = new OrderServiceClient();

                        var saveOrder = Observable.FromAsyncPattern<OrderHeader, OrderHeader>(
                            client.BeginSaveOrder,
                            client.EndSaveOrder
                        );

                        saveOrder( SelectedOrder )
                            .ObserveOnDispatcher()
                            .Subscribe(
                                result =>
                                {
                                    // update the order with the results of the save
                                    // NOTE: this will occur AFTER the RestoreObjectGraph() call below
                                    // because it is being invoked asynchronously (use debugger the verify)
                                    SelectedOrder.ApplyUpdates(result);
                                }
                            );

                        // restore the original object graph for the order
                        SelectedOrder.RestoreObjectGraph();
                    }
                );
            }
        }
    }
}
