using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VillaProject.Application.Features.Roles.Commands.DeleteRoleCommand;
using VillaProject.Application.Features.Roles.Commands.UpdateRoleCommand;
using VillaProject.Application.Features.Roles.CreateRoleCommand;
using VillaProject.Application.Features.Roles.Queries.GetRolesQuery;

namespace VillaProject.WebAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetRolesQueryRequest request, CancellationToken cancellationToken = default)
        {
            return CreateActionResultInstance(await Mediator.Send(request, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRoleCommandRequest request, CancellationToken cancellationToken = default)
        {
            return CreateActionResultInstance(await Mediator.Send(request, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateRoleCommandRequest request, CancellationToken cancellationToken = default)
        {
            return CreateActionResultInstance(await Mediator.Send(request, cancellationToken));
        }

        [HttpDelete("{RoleName}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteRoleCommandRequest request, CancellationToken cancellationToken = default)
        {
            return CreateActionResultInstance(await Mediator.Send(request, cancellationToken));
        }
    }
}
