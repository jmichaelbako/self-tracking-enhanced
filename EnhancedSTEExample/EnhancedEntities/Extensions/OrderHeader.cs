using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnhancedEntities
{
    public partial class OrderHeader
    {
        public void AddDetail()
        {
            var line = OrderDetails.Max(od => od.LineNumber) + 1;
            OrderDetails.Add(new OrderDetail { LineNumber = line });
        }
    }
}
