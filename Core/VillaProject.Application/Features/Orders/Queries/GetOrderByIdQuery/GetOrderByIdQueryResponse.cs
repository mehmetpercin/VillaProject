using VillaProject.Application.Dtos.Orders;

namespace VillaProject.Application.Features.Orders.Queries.GetOrderByIdQuery
{
    public class GetOrderByIdQueryResponse
    {
        public int OrderId { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
