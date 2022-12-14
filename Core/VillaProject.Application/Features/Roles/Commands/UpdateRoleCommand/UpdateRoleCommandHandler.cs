using MediatR;
using VillaProject.Application.Dtos.Responses;
using VillaProject.Application.Dtos.Roles;
using VillaProject.Application.Services;

namespace VillaProject.Application.Features.Roles.Commands.UpdateRoleCommand
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommandRequest, Result>
    {
        private readonly IRoleService _roleService;

        public UpdateRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<Result> Handle(UpdateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            await _roleService.UpdateUserRoleAsync(new RoleDto
            {
                Id = request.RoleId,
                Name = request.RoleName
            });

            return SuccessResult.Success(200);
        }
    }
}
