using MediatR;
using VillaProject.Application.Dtos.Responses;

namespace VillaProject.Application.Features.Orders.Queries.GetOrderByIdQuery
{
    public class GetOrderByIdQueryRequest : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
