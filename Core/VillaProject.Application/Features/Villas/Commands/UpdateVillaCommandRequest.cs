using MediatR;
using VillaProject.Application.Dtos.Responses;
using VillaProject.Application.Repositories;

namespace VillaProject.Application.Features.Villas.Commands
{
    public class UpdateVillaCommandRequest : IRequest<Response<object>>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public class UpdateVillaCommandRequestHandler : IRequestHandler<UpdateVillaCommandRequest, Response<object>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public UpdateVillaCommandRequestHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Response<object>> Handle(UpdateVillaCommandRequest request, CancellationToken cancellationToken)
            {
                if (!Guid.TryParse(request.Id, out _))
                {
                    return ErrorResponse.Fail("Wrong id format", 400);
                }
                var villa = await _unitOfWork.Villas.GetByIdAsync(request.Id, cancellationToken);
                if (villa != null)
                {
                    villa.Name = request.Name;
                    await _unitOfWork.Save(cancellationToken);
                }

                return SuccessResponse.Success(200);
            }
        }
    }
}
