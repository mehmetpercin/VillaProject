using MediatR;
using VillaProject.Application.Dtos.Responses;
using VillaProject.Application.Repositories;

namespace VillaProject.Application.Features.Villas.Commands.UpdateVillaCommand
{
    public class UpdateVillaCommandRequestHandler : IRequestHandler<UpdateVillaCommandRequest, Response>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateVillaCommandRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(UpdateVillaCommandRequest request, CancellationToken cancellationToken)
        {
            var villa = await _unitOfWork.Villas.GetByIdAsync(request.Id, cancellationToken);
            if (villa != null)
            {
                villa.Name = request.Name;
                await _unitOfWork.SaveAsync(cancellationToken);
            }

            return SuccessResponse.Success(200);
        }
    }
}
