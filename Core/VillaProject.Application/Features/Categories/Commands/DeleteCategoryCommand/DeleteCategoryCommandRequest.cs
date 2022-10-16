using MediatR;
using VillaProject.Application.Dtos.Responses;

namespace VillaProject.Application.Features.Categories.Commands.DeleteCategoryCommand
{
    public class DeleteCategoryCommandRequest : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
