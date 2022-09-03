using MediatR;
using VillaProject.Application.Dtos.Responses;

namespace VillaProject.Application.Features.Categories.Commands.CreateCategoryCommand
{
    public class CreateCategoryCommandRequest : IRequest<Response<int>>
    {
        public string Name { get; set; }
    }
}
