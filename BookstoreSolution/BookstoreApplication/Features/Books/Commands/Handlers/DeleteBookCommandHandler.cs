using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreApplication.Common.Interfaces;
using BookstoreApplication.Features.Books.Commands;
using System.Runtime.CompilerServices;

namespace BookstoreApplication.Features.Books.Commands.Handlers
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteBookCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(new object[] { request.Id }, cancellationToken);

            if (book == null)
            {
                return false;
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
