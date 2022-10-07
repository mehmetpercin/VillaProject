using MediatR;
using VillaProject.Application.Dtos.Responses;

namespace VillaProject.Application.Features.Users.Commands.AddUserRoleCommand
{
    public class AddUserRoleCommandRequest : IRequest<Response<object>>
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }
    }
}
