using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApplication.Features.Authors.Commands
{
    public class DeleteAuthorCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteAuthorCommand(int id)
        {
            Id = id;
        }
    }
}
