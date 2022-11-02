using MediatR;
using VillaProject.Application.Dtos.Categories;
using VillaProject.Application.Dtos.Responses;

namespace VillaProject.Application.Features.Categories.Queries.GetAllCategoriesQuery
{
    public class GetAllCategoriesQueryRequest : IRequest<Result>
    {
    }
}
