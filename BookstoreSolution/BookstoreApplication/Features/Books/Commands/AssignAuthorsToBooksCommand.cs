using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApplication.Features.Books.Commands
{
    public class AssignAuthorsToBooksCommand : IRequest<bool>
    {
        public int BookId { get; set; }
        public List<int> AuthorIds { get; set; } = new();
    }
}
