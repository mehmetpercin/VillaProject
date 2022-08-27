using VillaProject.Application.Dtos.Orders;

namespace VillaProject.Application.Features.Orders.Queries.GetOrderByIdQuery
{
    public class GetOrderByIdQueryResponse
    {
        public Guid OrderId { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
