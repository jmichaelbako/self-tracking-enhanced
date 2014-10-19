using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnhancedEntities;

namespace EnhancedDataAccess
{
    public class OrderRepository
    {
        public IEnumerable<OrderHeader> GetAll()
        {
            using (var context = new EnhancedEntities())
            {
                return context
                    .OrderHeaders
                        .Include("OrderDetails.Product.Categories")
                    .ToList<OrderHeader>();
            }
        }

        public OrderHeader Save(OrderHeader order)
        {
            using (var context = new EnhancedEntities())
            {
                context.OrderHeaders.ApplyChanges<OrderHeader>(order);
                context.SaveChanges();
                
                order.AcceptChanges();
                return order;
            }
        }
    }
}
