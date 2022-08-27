using MediatR;
using VillaProject.Application.Dtos.Responses;

namespace VillaProject.Application.Features.Villas.Commands.DeleteVillaCommand
{
    public class DeleteVillaCommandRequest : IRequest<Response<object>>
    {
        public Guid Id { get; set; }
    }
}
