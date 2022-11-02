using MediatR;
using VillaProject.Application.Dtos.Responses;

namespace VillaProject.Application.Features.Categories.Commands.UpdateCategoryCommand
{
    public class UpdateCategoryCommandRequest : IRequest<Result>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
