using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApplication.Features.Orders.Commands
{
    public class PlaceOrderCommand : IRequest<int>
    {
        public string CustomerId { get; set; }
        public List<int> BookIds { get; set; }
        public int ShippingMethodId {  get; set; }
        public int PaymentMethodId { get; set; }
    }
}
