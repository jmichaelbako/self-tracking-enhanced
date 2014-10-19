using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using EnhancedEntities;

namespace EnhancedServices
{
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        IEnumerable<OrderHeader> GetOrders();

        [OperationContract]
        OrderHeader SaveOrder(OrderHeader order);
    }
}
