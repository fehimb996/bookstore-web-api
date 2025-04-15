using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using BookstoreApplication.Features.Books.Commands;
using BookstoreDomain.Entities;
using Microsoft.EntityFrameworkCore;
using BookstoreApplication.Common.Interfaces;


namespace BookstoreApplication.Features.Books.Handlers
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateBookCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                Language = request.Language,
                ISBN = request.ISBN,
                DatePublished = request.DatePublished,
                Price = request.Price,
                ImageUrl = request.ImageUrl
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync(cancellationToken);

            return book.Id;
        }
    }
}