using MediatR;
using VillaProject.Application.Dtos.Products;
using VillaProject.Application.Dtos.Responses;

namespace VillaProject.Application.Features.Products.Queries.GetAllProductsQuery
{
    public class GetAllProductsQueryRequest : IRequest<Result>
    {
    }
}
