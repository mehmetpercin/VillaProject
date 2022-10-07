using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VillaProject.Application.Features.Roles.CreateRoleCommand;

namespace VillaProject.WebAPI.Controllers
{
    [Authorize]
    public class RolesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRoleCommandRequest request, CancellationToken cancellationToken = default)
        {
            return CreateActionResultInstance(await Mediator.Send(request, cancellationToken));
        }
    }
}
