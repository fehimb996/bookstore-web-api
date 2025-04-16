using BookstoreApplication.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApplication.Features.Authors.Commands.Handlers
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteAuthorCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

            if (author == null)
            {
                return false;
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
