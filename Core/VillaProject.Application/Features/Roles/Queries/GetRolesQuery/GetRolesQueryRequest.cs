using MediatR;
using VillaProject.Application.Dtos.Responses;
using VillaProject.Application.Dtos.Roles;

namespace VillaProject.Application.Features.Roles.Queries.GetRolesQuery
{
    public class GetRolesQueryRequest : IRequest<Result>
    {
    }
}
