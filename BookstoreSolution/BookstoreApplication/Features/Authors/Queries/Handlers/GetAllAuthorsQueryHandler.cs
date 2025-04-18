using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreApplication.Common.Interfaces;
using BookstoreApplication.Features.Authors.Queries;
using Microsoft.EntityFrameworkCore;
using BookstoreDomain.Entities;
using BookstoreApplication.Features.Authors.DTOs;
using BookstoreApplication.Features.Books.DTOs;

namespace BookstoreApplication.Features.Authors.Queries.Handlers
{
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, List<AuthorDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllAuthorsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<AuthorDTO>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Authors
                .Include(a => a.Books)
                .Select(a => new AuthorDTO
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Books = a.Books.Select(b => new BookDTO
                    {
                        Id = b.Id,
                        Title = b.Title,
                    }).ToList()
                }).ToListAsync(cancellationToken);
        }
    }
}
