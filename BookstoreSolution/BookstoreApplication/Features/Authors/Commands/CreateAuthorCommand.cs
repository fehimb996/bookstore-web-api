using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApplication.Features.Authors.Commands
{
    public class CreateAuthorCommand : IRequest<int> 
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
