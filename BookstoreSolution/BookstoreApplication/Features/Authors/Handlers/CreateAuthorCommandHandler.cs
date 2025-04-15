using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreDomain.Entities;
using BookstoreApplication.Common.Interfaces;
using BookstoreApplication.Features.Authors.Commands;

namespace BookstoreApplication.Features.Authors.Handlers
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateAuthorCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Author
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
            };

            _context.Authors.Add(author);
            await _context.SaveChangesAsync(cancellationToken);

            return author.Id;
        }
    }
}
