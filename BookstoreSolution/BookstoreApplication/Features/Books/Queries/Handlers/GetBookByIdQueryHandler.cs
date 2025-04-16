using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreApplication.Common.Interfaces;
using BookstoreApplication.Features.Books.Queries;
using BookstoreDomain.Entities;
using Microsoft.EntityFrameworkCore;
using BookstoreApplication.Features.Books.DTOs;
using BookstoreApplication.Features.Authors.DTOs;

namespace BookstoreApplication.Features.Books.Queries.Handlers
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDTO>
    {
        private readonly IApplicationDbContext _context;

        public GetBookByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BookDTO?> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _context.Books
                .Include(b => b.Authors)
                .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

            if (book == null) return null;

            return new BookDTO
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Language = book.Language,
                ISBN = book.ISBN,
                DatePublished = book.DatePublished,
                Price = book.Price,
                Authors = book.Authors.Select(a => new AuthorDTO
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName
                }).ToList()
            };
        }
    }
}
