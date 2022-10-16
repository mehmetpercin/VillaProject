using MediatR;
using VillaProject.Application.Dtos.Responses;

namespace VillaProject.Application.Features.Roles.Commands.UpdateRoleCommand
{
    public class UpdateRoleCommandRequest  :IRequest<Response>
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
