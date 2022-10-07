using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VillaProject.Application.Features.Users.Commands.AddUserRoleCommand;
using VillaProject.Application.Features.Users.Commands.RemoveUserRoleCommand;
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

        [HttpPost]
        [Route("add-role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddUserRole([FromBody] AddUserRoleCommandRequest request, CancellationToken cancellationToken = default)
        {
            return CreateActionResultInstance(await Mediator.Send(request, cancellationToken));
        }

        [HttpPost]
        [Route("remove-role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveUserRole([FromBody] RemoveUserRoleCommandRequest request, CancellationToken cancellationToken = default)
        {
            return CreateActionResultInstance(await Mediator.Send(request, cancellationToken));
        }
    }
}
