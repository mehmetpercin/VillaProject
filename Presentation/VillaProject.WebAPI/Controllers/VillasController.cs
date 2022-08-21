using MediatR;
using Microsoft.AspNetCore.Mvc;
using VillaProject.Application.Features.Villas.Commands;
using VillaProject.Application.Features.Villas.Queries;

namespace VillaProject.WebAPI.Controllers
{
    public class VillasController : BaseController
    {
        private readonly IMediator _mediator;

        public VillasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllVillasQueryRequest request, CancellationToken cancellationToken = default)
        {
            return CreateActionResultInstance(await _mediator.Send(request, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVillaCommandRequest request, CancellationToken cancellationToken = default)
        {
            return CreateActionResultInstance(await _mediator.Send(request, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateVillaCommandRequest request, CancellationToken cancellationToken = default)
        {
            return CreateActionResultInstance(await _mediator.Send(request, cancellationToken));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteVillaCommandRequest request, CancellationToken cancellationToken = default)
        {
            return CreateActionResultInstance(await _mediator.Send(request, cancellationToken));
        }
    }
}
