using MediatR;
using VillaProject.Application.Dtos.Responses;

namespace VillaProject.Application.Features.Roles.CreateRoleCommand
{
    public class CreateRoleCommandRequest : IRequest<Response>
    {
        public string RoleName { get; set; }
    }
}
