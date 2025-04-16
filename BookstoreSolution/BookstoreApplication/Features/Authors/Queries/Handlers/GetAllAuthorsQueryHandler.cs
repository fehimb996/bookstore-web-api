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

namespace BookstoreApplication.Features.Authors.Queries.Handlers
{
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, List<Author>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllAuthorsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Author>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Authors.ToListAsync(cancellationToken);
        }
    }
}
