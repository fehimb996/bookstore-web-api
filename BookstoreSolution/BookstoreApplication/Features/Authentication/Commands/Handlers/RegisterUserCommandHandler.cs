using MediatR;
using BookstoreApplication.Features.Authentication.DTOs;
using BookstoreApplication.Common.Interfaces;

namespace BookstoreApplication.Features.Authentication.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, AuthResponse>
    {
        private readonly IAuthService _authService;

        public RegisterUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<AuthResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            return await _authService.RegisterAsync(request.RegisterRequest);
        }
    }
}
