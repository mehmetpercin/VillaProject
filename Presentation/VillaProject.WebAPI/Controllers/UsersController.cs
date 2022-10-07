using Microsoft.AspNetCore.Mvc;
using VillaProject.Application.Features.Users.RegisterCommand;

namespace VillaProject.WebAPI.Controllers
{
    public class UsersController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterCommandRequest request, CancellationToken cancellationToken = default)
        {
            return CreateActionResultInstance(await Mediator.Send(request, cancellationToken));
        }
    }
}
