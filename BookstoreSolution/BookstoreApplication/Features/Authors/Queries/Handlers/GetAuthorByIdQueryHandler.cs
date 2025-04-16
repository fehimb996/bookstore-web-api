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

namespace BookstoreApplication.Features.Authors.Queries.Handlers
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, Author?>
    {
        private readonly IApplicationDbContext _context;

        public GetAuthorByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Author?> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Authors.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);
        }
    }
}
