using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BookstoreInfrastructure.Identity;
using MediatR;
using BookstoreApplication.Features.Authentication.DTOs;
using BookstoreApplication.Features.Authentication.Commands;

namespace BookstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(new RegisterUserCommand { RegisterRequest = request});
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(new LoginUserCommand { LoginRequest = request });
            

            if (!result.IsSuccessful)
            {
                return BadRequest(ModelState);
            }

            return Ok(result);
        }
    }
}
