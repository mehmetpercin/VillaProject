using AutoMapper;
using MediatR;
using VillaProject.Application.Dtos.Orders;
using VillaProject.Application.Dtos.Responses;
using VillaProject.Application.Repositories;
using VillaProject.Domain.Entities;
using VillaProject.Domain.Enums;

namespace VillaProject.Application.Features.Orders.Commands.CreateOrderCommand
{
    public class CreateOrderCommandRequestHandler : IRequestHandler<CreateOrderCommandRequest, Response<CreatedOrderDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOrderCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<CreatedOrderDto>> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var orderItems = _mapper.Map<List<OrderItem>>(request.OrderItems);
            var newOrder = new Order
            {
                OrderItems = orderItems,
                StatusId = OrderStatusEnum.Open,
                VillaId = request.VillaId
            };

            await _unitOfWork.Orders.AddAsync(newOrder, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);

            return SuccessDataResponse<CreatedOrderDto>.Success(new CreatedOrderDto
            {
                OrderId = newOrder.Id,
                VillaId = newOrder.VillaId,
                TotalPrice = newOrder.OrderItems.Sum(x => x.Quantity * x.Price)
            }, 201);
        }
    }
}
