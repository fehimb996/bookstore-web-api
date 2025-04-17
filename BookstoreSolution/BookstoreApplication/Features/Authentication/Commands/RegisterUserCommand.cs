using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreApplication.Features.Authentication.DTOs;

namespace BookstoreApplication.Features.Authentication.Commands
{
    public class RegisterUserCommand : IRequest<AuthResponse>
    {
        public RegisterRequest RegisterRequest { get; set; }
    }
}
