using MediatR;
using VillaProject.Application.Dtos.Responses;
using VillaProject.Application.Dtos.Roles;
using VillaProject.Application.Services;

namespace VillaProject.Application.Features.Roles.Queries.GetRolesQuery
{
    public class GetRolesQueryHandler : IRequestHandler<GetRolesQueryRequest, Result>
    {
        private readonly IRoleService _roleService;

        public GetRolesQueryHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<Result> Handle(GetRolesQueryRequest request, CancellationToken cancellationToken)
        {
            var roles = await _roleService.GetUserRolesAsync();
            return SuccessDataResult.Success(roles, 200);
        }
    }
}
