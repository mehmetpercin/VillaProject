using Microsoft.AspNetCore.Mvc;
using VillaProject.Application.Features.Products.Commands.CreateProductCommand;
using VillaProject.Application.Features.Products.Commands.DeleteProductCommand;
using VillaProject.Application.Features.Products.Commands.UpdateProductCommand;
using VillaProject.Application.Features.Products.Queries.GetAllProductsQuery;

namespace VillaProject.WebAPI.Controllers
{
    public class ProductsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductsQueryRequest request, CancellationToken cancellationToken = default)
        {
            return CreateActionResultInstance(await Mediator.Send(request, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommandRequest request, CancellationToken cancellationToken = default)
        {
            return CreateActionResultInstance(await Mediator.Send(request, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommandRequest request, CancellationToken cancellationToken = default)
        {
            return CreateActionResultInstance(await Mediator.Send(request, cancellationToken));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProductCommandRequest request, CancellationToken cancellationToken = default)
        {
            return CreateActionResultInstance(await Mediator.Send(request, cancellationToken));
        }
    }
}
