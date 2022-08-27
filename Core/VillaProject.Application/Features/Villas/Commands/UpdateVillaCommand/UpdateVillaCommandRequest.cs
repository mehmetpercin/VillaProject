using MediatR;
using VillaProject.Application.Dtos.Responses;

namespace VillaProject.Application.Features.Villas.Commands.UpdateVillaCommand
{
    public class UpdateVillaCommandRequest : IRequest<Response<object>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
