using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BookstoreApplication.Features.Books.Commands
{
    public class DeleteBookCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
