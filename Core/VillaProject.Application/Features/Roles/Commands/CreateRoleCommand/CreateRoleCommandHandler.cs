using MediatR;
using VillaProject.Application.Dtos.Responses;
using VillaProject.Application.Services;

namespace VillaProject.Application.Features.Roles.CreateRoleCommand
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommandRequest, Response<string>>
    {
        private readonly IRoleService _roleService;

        public CreateRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<Response<string>> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _roleService.AddUserRoleAsync(request.RoleName);
            return SuccessDataResponse<string>.Success(result, 201);
        }
    }
}
