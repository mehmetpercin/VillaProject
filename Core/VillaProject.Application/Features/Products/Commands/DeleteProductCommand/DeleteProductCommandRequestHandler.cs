using MediatR;
using VillaProject.Application.Dtos.Responses;
using VillaProject.Application.Repositories;

namespace VillaProject.Application.Features.Products.Commands.DeleteProductCommand
{
    public class DeleteProductCommandRequestHandler : IRequestHandler<DeleteProductCommandRequest, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var hasAnyOrder = await _unitOfWork.Orders.AnyAsync(x => x.OrderItems.Any(o => o.ProductId == request.Id), cancellationToken);
            if (hasAnyOrder)
                return ErrorResult.Fail("Product cannot delete because of has order!", 400);

            var product = await _unitOfWork.Products.GetByIdAsync(request.Id, cancellationToken, false);
            if (product != null)
            {
                await _unitOfWork.Products.RemoveAsync(product, cancellationToken);
                await _unitOfWork.SaveAsync(cancellationToken);
            }

            return SuccessResult.Success(200);
        }
    }
}
