using MediatR;
using VillaProject.Application.Dtos.Orders;
using VillaProject.Application.Dtos.Responses;

namespace VillaProject.Application.Features.Orders.Commands.CreateOrderCommand
{
    public class CreateOrderCommandRequest : IRequest<Response<CreatedOrderDto>>
    {
        public int VillaId { get; set; }
        public List<OrderItemCreateDto> OrderItems { get; set; }
    }
}
