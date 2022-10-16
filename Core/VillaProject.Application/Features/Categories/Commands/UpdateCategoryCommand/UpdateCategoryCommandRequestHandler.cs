using MediatR;
using VillaProject.Application.Dtos.Responses;
using VillaProject.Application.Repositories;

namespace VillaProject.Application.Features.Categories.Commands.UpdateCategoryCommand
{
    public class UpdateCategoryCommandRequestHandler : IRequestHandler<UpdateCategoryCommandRequest, Response>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryCommandRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Response> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var exists = await _unitOfWork.Categories.AnyAsync(x => x.Name == request.Name, cancellationToken);
            if (exists)
                return ErrorResponse.Fail("Category with this name already exists!", 400);

            var category = await _unitOfWork.Categories.GetByIdAsync(request.Id, cancellationToken);
            if (category != null)
            {
                category.Name = request.Name;
                await _unitOfWork.SaveAsync(cancellationToken);
            }

            return SuccessResponse.Success(200);
        }
    }
}
