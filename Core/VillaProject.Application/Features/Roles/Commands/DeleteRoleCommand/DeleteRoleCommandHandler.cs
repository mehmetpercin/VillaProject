using MediatR;
using VillaProject.Application.Dtos.Responses;
using VillaProject.Application.Services;

namespace VillaProject.Application.Features.Roles.Commands.DeleteRoleCommand
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommandRequest, Result>
    {
        private readonly IRoleService _roleService;

        public DeleteRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<Result> Handle(DeleteRoleCommandRequest request, CancellationToken cancellationToken)
        {
            await _roleService.DeleteUserRoleAsync(request.RoleName);
            return SuccessResult.Success(200);
        }
    }
}
