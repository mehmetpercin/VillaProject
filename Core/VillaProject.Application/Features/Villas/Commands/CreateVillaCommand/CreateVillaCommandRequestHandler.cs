using MediatR;
using VillaProject.Application.Dtos.Responses;
using VillaProject.Application.Repositories;
using VillaProject.Domain.Entities;

namespace VillaProject.Application.Features.Villas.Commands.CreateVillaCommand
{
    public class CreateVillaCommandRequestHandler : IRequestHandler<CreateVillaCommandRequest, Response>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateVillaCommandRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(CreateVillaCommandRequest request, CancellationToken cancellationToken)
        {
            var villa = new Villa
            {
                Name = request.Name
            };

            await _unitOfWork.Villas.AddAsync(villa, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);
            return SuccessDataResponse.Success(villa.Id, 200);
        }
    }
}
