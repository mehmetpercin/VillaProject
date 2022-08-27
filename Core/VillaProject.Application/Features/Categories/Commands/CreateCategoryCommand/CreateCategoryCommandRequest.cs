using MediatR;
using VillaProject.Application.Dtos.Responses;

namespace VillaProject.Application.Features.Categories.Commands.CreateCategoryCommand
{
    public class CreateCategoryCommandRequest : IRequest<Response<Guid>>
    {
        public string Name { get; set; }
    }
}
