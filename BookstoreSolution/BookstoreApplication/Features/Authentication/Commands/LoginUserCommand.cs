using BookstoreApplication.Features.Authentication.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApplication.Features.Authentication.Commands
{
    public class LoginUserCommand : IRequest<AuthResponse>
    {
        public LoginRequest LoginRequest { get; set; }
    }
}
