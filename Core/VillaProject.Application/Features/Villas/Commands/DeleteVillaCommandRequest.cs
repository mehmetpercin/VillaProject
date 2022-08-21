using MediatR;
using VillaProject.Application.Dtos.Responses;
using VillaProject.Application.Repositories;

namespace VillaProject.Application.Features.Villas.Commands
{
    public class DeleteVillaCommandRequest : IRequest<Response<object>>
    {
        public string Id { get; set; }
        public class DeleteVillaCommandRequestHandler : IRequestHandler<DeleteVillaCommandRequest, Response<object>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public DeleteVillaCommandRequestHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Response<object>> Handle(DeleteVillaCommandRequest request, CancellationToken cancellationToken)
            {
                var villa = await _unitOfWork.Villas.GetByIdAsync(request.Id, cancellationToken, false);
                if (villa != null)
                {
                    await _unitOfWork.Villas.RemoveAsync(villa, cancellationToken);
                    await _unitOfWork.SaveAsync(cancellationToken);
                }

                return SuccessResponse.Success(200);
            }
        }
    }
}
