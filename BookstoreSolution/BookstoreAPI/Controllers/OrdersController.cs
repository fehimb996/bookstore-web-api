using BookstoreApplication.Features.Orders.DTOs;
using BookstoreApplication.Features.Orders.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace BookstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IHttpContextAccessor _ContextAccessor;
        private readonly IMediator _mediator;
        private readonly ILogger<OrdersController> _logger; 

        public OrdersController(IHttpContextAccessor contextAccessor, IMediator mediator, ILogger<OrdersController> logger)
        {
            _ContextAccessor = contextAccessor;
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("purchase")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Purchase([FromBody] PurchaseRequestDTO request)
        {
            var userId = _ContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value ??
                _ContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var claims = _ContextAccessor.HttpContext?.User?.Claims;

            if(claims != null)
            {
                foreach(var claim in claims)
                {
                    _logger.LogInformation($"Claim type: {claim.Type}, Claim value: {claim.Value}");
                }
            }

            _logger.LogInformation("Purchase endpoint reached!");


            if (userId == null)
            {
                return Unauthorized("User is not logged in");
            }

            var command = new PlaceOrderCommand
            {
                CustomerId = userId,
                BookIds = request.BookIds,
                ShippingMethodId = request.ShippingMethodId,
                PaymentMethodId = request.PaymentMethodId
            };

            var orderId = await _mediator.Send(command);

            return Ok(orderId);
        }
    }
}
