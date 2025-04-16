using BookstoreApplication.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Features.Authors.Commands.Handlers
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public UpdateAuthorCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

            if(author == null)
            {
                return false;
            }

            author.FirstName = request.FirstName;
            author.LastName = request.LastName;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
