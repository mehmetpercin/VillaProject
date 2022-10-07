using MediatR;
using VillaProject.Application.Dtos.Responses;

namespace VillaProject.Application.Features.Roles.Commands.DeleteRoleCommand
{
    public class DeleteRoleCommandRequest : IRequest<Response<object>>
    {
        public string RoleName { get; set; }
    }
}
