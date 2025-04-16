using MediatR;
using BookstoreApplication.Common.Interfaces;
using BookstoreApplication.Features.Books.Commands;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Features.Books.Handlers
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public UpdateBookCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(new object[] { request.Id }, cancellationToken);

            if (book == null) return false;

            book.Title = request.Title;
            book.Description = request.Description;
            book.Language = request.Language;
            book.ISBN = request.ISBN;
            book.DatePublished = request.DatePublished;
            book.Price = request.Price;
            book.ImageUrl = request.ImageUrl;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
