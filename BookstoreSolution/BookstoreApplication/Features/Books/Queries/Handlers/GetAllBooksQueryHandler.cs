using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreDomain.Entities;
using BookstoreApplication.Common.Interfaces;
using BookstoreApplication.Features.Books.Queries;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using BookstoreApplication.Features.Books.DTOs;
using BookstoreApplication.Features.Authors.DTOs;

namespace BookstoreApplication.Features.Books.Queries.Handlers
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<BookDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllBooksQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<BookDTO>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            return await _context.Books
                .Include(b => b.Authors)
                .Select(b => new BookDTO
            {
                Id = b.Id,
                Title = b.Title,
                Description = b.Description,
                Language = b.Language,
                ISBN = b.ISBN,
                Price = b.Price,
                DatePublished = b.DatePublished,
                Authors = b.Authors.Select(a => new AuthorDTO
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName
                }).ToList()
            }).ToListAsync(cancellationToken);
        }
    }
}
