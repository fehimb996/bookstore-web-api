using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreDomain.Entities
{
    public class ShippingMethod
    {
        public int ShippingMethodId { get; set; }
        public string MethodName { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
