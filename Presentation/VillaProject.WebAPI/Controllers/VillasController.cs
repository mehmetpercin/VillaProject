using MediatR;
using Microsoft.AspNetCore.Mvc;
using VillaProject.Application.Features.Villas.Commands.CreateVillaCommand;
using VillaProject.Application.Features.Villas.Commands.DeleteVillaCommand;
using VillaProject.Application.Features.Villas.Commands.UpdateVillaCommand;
using VillaProject.Application.Features.Villas.Queries;

namespace VillaProject.WebAPI.Controllers
{
    public class VillasController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllVillasQueryRequest request, CancellationToken cancellationToken = default)
        {
            return CreateActionResultInstance(await Mediator.Send(request, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVillaCommandRequest request, CancellationToken cancellationToken = default)
        {
            return CreateActionResultInstance(await Mediator.Send(request, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateVillaCommandRequest request, CancellationToken cancellationToken = default)
        {
            return CreateActionResultInstance(await Mediator.Send(request, cancellationToken));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteVillaCommandRequest request, CancellationToken cancellationToken = default)
        {
            return CreateActionResultInstance(await Mediator.Send(request, cancellationToken));
        }
    }
}
