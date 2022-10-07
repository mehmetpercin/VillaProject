using Microsoft.AspNetCore.Mvc;
using VillaProject.Application.Features.Users.LoginCommand;
using VillaProject.Application.Features.Users.RefreshTokenLoginCommand;

namespace VillaProject.WebAPI.Controllers
{
    public class AuthController : BaseController
    {
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommandRequest request, CancellationToken cancellationToken = default)
        {
            return CreateActionResultInstance(await Mediator.Send(request, cancellationToken));
        }

        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshTokenLogin([FromBody] RefreshTokenLoginCommandRequest request, CancellationToken cancellationToken = default)
        {
            return CreateActionResultInstance(await Mediator.Send(request, cancellationToken));
        }
    }
}
