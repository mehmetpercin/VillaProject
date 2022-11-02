using MediatR;
using VillaProject.Application.Dtos.Responses;

namespace VillaProject.Application.Features.Users.Commands.RemoveUserRoleCommand
{
    public class RemoveUserRoleCommandRequest : IRequest<Result>
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }
    }
}
