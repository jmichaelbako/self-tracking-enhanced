using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using EnhancedDataAccess;
using EnhancedEntities;

namespace EnhancedServices
{
    public class OrderService : IOrderService
    {
        private OrderRepository _repository = new OrderRepository();

        public IEnumerable<OrderHeader> GetOrders()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                throw new FaultException<Exception>(ex);
            }
        }

        public OrderHeader SaveOrder(OrderHeader order)
        {
            try
            {
                return _repository.Save(order);
            }
            catch (Exception ex)
            {
                throw new FaultException<Exception>(ex);
            }
        }
    }
}
