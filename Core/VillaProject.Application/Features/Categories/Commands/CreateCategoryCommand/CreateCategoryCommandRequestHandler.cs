using MediatR;
using VillaProject.Application.Dtos.Responses;
using VillaProject.Application.Repositories;
using VillaProject.Domain.Entities;

namespace VillaProject.Application.Features.Categories.Commands.CreateCategoryCommand
{
    public class CreateCategoryCommandRequestHandler : IRequestHandler<CreateCategoryCommandRequest, Response<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryCommandRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<int>> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var exists = await _unitOfWork.Categories.AnyAsync(x => x.Name == request.Name, cancellationToken);
            if (exists)
                return ErrorResponse<int>.Fail("Category already exists!", 400);

            var category = await _unitOfWork.Categories.AddAsync(new Category
            {
                Name = request.Name
            }, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);

            return SuccessDataResponse<int>.Success(category.Id, 200);
        }
    }
}
