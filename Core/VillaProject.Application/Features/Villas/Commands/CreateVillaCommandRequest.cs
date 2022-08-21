using MediatR;
using VillaProject.Application.Dtos.Responses;
using VillaProject.Application.Repositories;
using VillaProject.Domain;

namespace VillaProject.Application.Features.Villas.Commands
{
    public class CreateVillaCommandRequest : IRequest<Response<Guid>>
    {
        public string Name { get; set; }

        public class CreateVillaCommandRequestHandler : IRequestHandler<CreateVillaCommandRequest, Response<Guid>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public CreateVillaCommandRequestHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Response<Guid>> Handle(CreateVillaCommandRequest request, CancellationToken cancellationToken)
            {
                var villa = new Villa
                {
                    Name = request.Name
                };

                await _unitOfWork.Villas.AddAsync(villa, cancellationToken);
                await _unitOfWork.SaveAsync(cancellationToken);
                return SuccessDataResponse<Guid>.Success(villa.Id, 200);
            }
        }
    }
}
