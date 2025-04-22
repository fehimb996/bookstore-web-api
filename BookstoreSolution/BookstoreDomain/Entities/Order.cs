using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookstoreDomain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }

        public int ShippingMethodId { get; set; }
        public ShippingMethod ShippingMethod { get; set; }

        public int OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
