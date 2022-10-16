using MediatR;
using VillaProject.Application.Dtos.Responses;
using VillaProject.Application.Services;

namespace VillaProject.Application.Features.Roles.Commands.DeleteRoleCommand
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommandRequest, Response>
    {
        private readonly IRoleService _roleService;

        public DeleteRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<Response> Handle(DeleteRoleCommandRequest request, CancellationToken cancellationToken)
        {
            await _roleService.DeleteUserRoleAsync(request.RoleName);
            return SuccessResponse.Success(200);
        }
    }
}
