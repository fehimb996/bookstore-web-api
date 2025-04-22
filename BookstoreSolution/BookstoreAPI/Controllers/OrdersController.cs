using BookstoreApplication.Features.Orders.DTOs;
using BookstoreApplication.Features.Orders.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IHttpContextAccessor _ContextAccessor;
        private readonly IMediator _mediator;

        public OrdersController(IHttpContextAccessor contextAccessor, IMediator mediator)
        {
            _ContextAccessor = contextAccessor;
            _mediator = mediator;
        }

        [HttpPost("purchase")]
        [Authorize]  
        public async Task<IActionResult> Purchase([FromBody] PurchaseRequestDTO request)
        {
            var userId = _ContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

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
