using MediatR;
using VillaProject.Application.Dtos.Responses;
using VillaProject.Application.Repositories;
using VillaProject.Domain.Entities;

namespace VillaProject.Application.Features.Products.Commands.CreateProductCommand
{
    public class CreateProductCommandRequestHandler : IRequestHandler<CreateProductCommandRequest, Response<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<Guid>> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                CategoryId = request.CategoryId,
                Price = request.Price
            };

            await _unitOfWork.Products.AddAsync(product, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);

            return SuccessDataResponse<Guid>.Success(product.Id, 200);
        }
    }
}
