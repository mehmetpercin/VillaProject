using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VillaProject.Application.Features.Orders.Commands.CreateOrderCommand;

namespace VillaProject.WebAPI.Controllers
{
    [Authorize]
    public class OrdersController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderCommandRequest request, CancellationToken cancellationToken = default)
        {
            return CreateActionResultInstance(await Mediator.Send(request, cancellationToken));
        }
    }
}
