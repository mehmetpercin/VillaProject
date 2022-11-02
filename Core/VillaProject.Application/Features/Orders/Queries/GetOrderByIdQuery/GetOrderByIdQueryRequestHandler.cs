using MediatR;
using VillaProject.Application.Dtos.Orders;
using VillaProject.Application.Dtos.Responses;
using VillaProject.Application.Repositories;

namespace VillaProject.Application.Features.Orders.Queries.GetOrderByIdQuery
{
    public class GetOrderByIdQueryRequestHandler : IRequestHandler<GetOrderByIdQueryRequest,Result>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByIdQueryRequestHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result> Handle(GetOrderByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderWithOrderItemsByIdAsync(request.Id, cancellationToken);
            if (order == null)
                return SuccessDataResult.Success(null, 200);

            var response = new GetOrderByIdQueryResponse
            {
                OrderId = order.Id,
                OrderItems = order.OrderItems.Select(x => new OrderItemDto
                {
                    Id = x.Id,
                    Price = x.Price,
                    ProductId = x.ProductId.ToString(),
                    Quantity = x.Quantity
                }).ToList(),
                TotalPrice = order.OrderItems.Sum(x => x.Price * x.Quantity)
            };

            return SuccessDataResult.Success(response, 200);
        }
    }
}
