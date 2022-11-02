using MediatR;
using VillaProject.Application.Dtos.Responses;

namespace VillaProject.Application.Features.Villas.Commands.DeleteVillaCommand
{
    public class DeleteVillaCommandRequest : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
