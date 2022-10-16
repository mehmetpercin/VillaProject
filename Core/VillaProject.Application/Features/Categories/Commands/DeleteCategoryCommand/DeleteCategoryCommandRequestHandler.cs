using MediatR;
using VillaProject.Application.Dtos.Responses;
using VillaProject.Application.Repositories;

namespace VillaProject.Application.Features.Categories.Commands.DeleteCategoryCommand
{
    public class DeleteCategoryCommandRequestHandler : IRequestHandler<DeleteCategoryCommandRequest, Response>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryCommandRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.Categories.GetFirstAsync(x => x.Id == request.Id, cancellationToken);
            if (category != null)
            {
                await _unitOfWork.Categories.RemoveAsync(category, cancellationToken);
                await _unitOfWork.SaveAsync(cancellationToken);
            }

            return SuccessResponse.Success(200);
        }
    }
}
