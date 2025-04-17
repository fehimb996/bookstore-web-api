using BookstoreApplication.Features.Authentication.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreApplication.Common.Interfaces;

namespace BookstoreApplication.Features.Authentication.Commands.Handlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AuthResponse>
    {
        private readonly IAuthService _authService;

        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<AuthResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            return await _authService.LoginAsync(request.LoginRequest);
        }
    }
}
