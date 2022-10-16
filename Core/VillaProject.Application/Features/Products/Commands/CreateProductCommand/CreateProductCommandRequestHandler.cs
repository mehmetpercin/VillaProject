using MediatR;
using VillaProject.Application.Dtos.Responses;
using VillaProject.Application.Repositories;
using VillaProject.Domain.Entities;

namespace VillaProject.Application.Features.Products.Commands.CreateProductCommand
{
    public class CreateProductCommandRequestHandler : IRequestHandler<CreateProductCommandRequest, Response>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var categoryResult = await _unitOfWork.Categories.AnyAsync(x => x.Id == request.CategoryId, cancellationToken);
            if (!categoryResult)
            {
                return ErrorResponse.Fail("Category did not find!", 400);
            }

            var product = new Product
            {
                Name = request.Name,
                CategoryId = request.CategoryId,
                Price = request.Price,
                IsActive = true
            };

            await _unitOfWork.Products.AddAsync(product, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);

            return SuccessDataResponse.Success(product.Id, 200);
        }
    }
}
