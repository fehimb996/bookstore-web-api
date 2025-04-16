using BookstoreApplication.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Features.Books.Commands.Handlers
{
    public class AssignAuthorsToBooksCommandHandler : IRequestHandler<AssignAuthorsToBooksCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public AssignAuthorsToBooksCommandHandler(IApplicationDbContext context) 
        { 
            _context = context;
        }

        public async Task<bool> Handle(AssignAuthorsToBooksCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books
                .Include(b => b.Authors)
                .FirstOrDefaultAsync(b => b.Id == request.BookId, cancellationToken);

            if (book == null)
            {
                return false;
            }

            var authors = await _context.Authors
                .Where(a => request.AuthorIds.Contains(a.Id))
                .ToListAsync(cancellationToken);

            book.Authors.Clear();
            foreach (var author in authors)
            {
                book.Authors.Add(author);
            }

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
