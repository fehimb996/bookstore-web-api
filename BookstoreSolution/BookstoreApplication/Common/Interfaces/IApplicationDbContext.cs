using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BookstoreDomain.Entities;

namespace BookstoreApplication.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Book> Books { get; }
        DbSet<Author> Authors { get; }
        DbSet<Order> Orders { get; }
        DbSet<OrderLineItem> OrderLineItems { get; }
        DbSet<OrderStatus> OrderStatuses { get; }
        DbSet<PaymentMethod> PaymentMethods { get; }
        DbSet<ShippingMethod> ShippingMethods { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
