using MediatR;
using VillaProject.Application.Dtos.Responses;
using VillaProject.Application.Repositories;

namespace VillaProject.Application.Features.Villas.Commands.DeleteVillaCommand
{
    public class DeleteVillaCommandRequestHandler : IRequestHandler<DeleteVillaCommandRequest, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteVillaCommandRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteVillaCommandRequest request, CancellationToken cancellationToken)
        {
            var villa = await _unitOfWork.Villas.GetByIdAsync(request.Id, cancellationToken, false);
            if (villa != null)
            {
                await _unitOfWork.Villas.RemoveAsync(villa, cancellationToken);
                await _unitOfWork.SaveAsync(cancellationToken);
            }

            return SuccessResult.Success(200);
        }
    }
}
