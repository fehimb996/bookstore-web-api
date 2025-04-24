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

        public int? ShippingAddressId { get; set; }
        public ShippingAddress? ShippingAddress { get; set; }

        public decimal SubTotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal? ShippingFee { get; set; }
        public decimal Total { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string? FailureReason { get; set; }

        public ICollection<OrderLineItem> OrderLineItems { get; set; }
    }
}
