﻿using Microsoft.AspNetCore.Mvc;
using VillaProject.Application.Features.Categories.Commands.CreateCategoryCommand;
using VillaProject.Application.Features.Categories.Commands.DeleteCategoryCommand;
using VillaProject.Application.Features.Categories.Commands.UpdateCategoryCommand;
using VillaProject.Application.Features.Categories.Queries.GetAllCategoriesQuery;

namespace VillaProject.WebAPI.Controllers
{
    public class CategoriesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllCategoriesQueryRequest request, CancellationToken cancellationToken = default)
        {
            return CreateActionResultInstance(await Mediator.Send(request, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommandRequest request, CancellationToken cancellationToken = default)
        {
            return CreateActionResultInstance(await Mediator.Send(request, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommandRequest request, CancellationToken cancellationToken = default)
        {
            return CreateActionResultInstance(await Mediator.Send(request, cancellationToken));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCategoryCommandRequest request, CancellationToken cancellationToken = default)
        {
            return CreateActionResultInstance(await Mediator.Send(request, cancellationToken));
        }
    }
}
