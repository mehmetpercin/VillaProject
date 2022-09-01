using MediatR;
using VillaProject.Application.Dtos;
using VillaProject.Application.Dtos.Responses;

namespace VillaProject.Application.Features.Products.Queries.GetAllProductsQuery
{
    public class GetAllProductsQueryRequest : IRequest<Response<List<ProductListDto>>>
    {
    }
}
