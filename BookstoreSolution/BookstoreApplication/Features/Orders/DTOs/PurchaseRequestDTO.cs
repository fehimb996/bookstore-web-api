using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApplication.Features.Orders.DTOs
{
    public class PurchaseRequestDTO
    {
        public List<int> BookIds { get; set; }
        public int ShippingMethodId { get; set; }
        public int PaymentMethodId { get; set; }
    }
}
