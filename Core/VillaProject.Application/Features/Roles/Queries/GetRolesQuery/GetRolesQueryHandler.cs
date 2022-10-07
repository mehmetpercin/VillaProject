using MediatR;
using VillaProject.Application.Dtos.Responses;
using VillaProject.Application.Dtos.Roles;
using VillaProject.Application.Services;

namespace VillaProject.Application.Features.Roles.Queries.GetRolesQuery
{
    public class GetRolesQueryHandler : IRequestHandler<GetRolesQueryRequest, Response<List<RoleDto>>>
    {
        private readonly IRoleService _roleService;

        public GetRolesQueryHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<Response<List<RoleDto>>> Handle(GetRolesQueryRequest request, CancellationToken cancellationToken)
        {
            var roles = await _roleService.GetUserRolesAsync();
            return SuccessDataResponse<List<RoleDto>>.Success(roles, 200);
        }
    }
}
