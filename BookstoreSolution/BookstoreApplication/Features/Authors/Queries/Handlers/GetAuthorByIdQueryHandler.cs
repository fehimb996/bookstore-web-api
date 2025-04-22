using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreDomain.Entities;
using BookstoreApplication.Common.Interfaces;
using BookstoreApplication.Features.Authors.Queries;
using Microsoft.EntityFrameworkCore;
using BookstoreApplication.Features.Authors.DTOs;
using BookstoreApplication.Features.Books.DTOs;

namespace BookstoreApplication.Features.Authors.Queries.Handlers
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, AuthorDTO?>
    {
        private readonly IApplicationDbContext _context;

        public GetAuthorByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AuthorDTO?> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Authors
                .Include(a => a.Books)
                .Where(a => a.Id == request.Id)
                .Select(a => new AuthorDTO
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Books = a.Books.Select(b => new BookBasicDTO
                    {
                        Id = b.Id,
                        Title = b.Title,
                        Description = b.Description,
                        Language = b.Language,
                        ISBN = b.ISBN,
                        Price = b.Price,
                        DatePublished = b.DatePublished,
                        ImageUrl = b.ImageUrl
                    }).ToList()
                })
                .FirstOrDefaultAsync(cancellationToken); 
        }
    }
}
