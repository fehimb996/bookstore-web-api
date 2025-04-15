using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BookstoreApplication.Features.Books.Commands
{
    public class CreateBookCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Language {  get; set; }
        public string ISBN { get; set; }
        public DateTime? DatePublished { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }

        public List<Guid> AuthorIds { get; set; } = new();
    }
}
