using BookstoreApplication.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreDomain.Entities;
using BookstoreApplication.Features.Orders.DTOs;

namespace BookstoreApplication.Features.Orders.Commands.Handlers
{
    public class PlaceOrderCommandHandler : IRequestHandler<PlaceOrderCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public PlaceOrderCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
        {
            decimal totalPrice = 0;
            var orderDetails = new List<OrderDetail>();

            foreach(var bookId in request.BookIds)
            {
                var book = await _context.Books.FindAsync(bookId);
                if(book != null)
                {
                    totalPrice += book.Price;
                    orderDetails.Add(new OrderDetail
                    {
                        BookId = bookId,
                        Quantity = 1
                    });
                }
            }

            var order = new Order
            {
                CustomerId = request.CustomerId,
                ShippingMethodId = request.ShippingMethodId,
                PaymentMethodId = request.PaymentMethodId,
                OrderStatusId = 1,
                OrderDate = DateTime.UtcNow,
                OrderDetails = request.BookIds.Select(bookId => new OrderDetail
                {
                    BookId = bookId,
                    Quantity = 1
                }).ToList()
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync(cancellationToken);

            return order.OrderId;
        }
    }
}
