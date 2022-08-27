using MediatR;
using VillaProject.Application.Dtos.Responses;

namespace VillaProject.Application.Features.Categories.Commands.DeleteCategoryCommand
{
    public class DeleteCategoryCommandRequest : IRequest<Response<object>>
    {
        public Guid Id { get; set; }
    }
}
