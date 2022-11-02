using AutoMapper;
using MediatR;
using VillaProject.Application.Dtos.Responses;
using VillaProject.Application.Repositories;

namespace VillaProject.Application.Features.Products.Commands.UpdateProductCommand
{
    public class UpdateProductCommandRequestHandler : IRequestHandler<UpdateProductCommandRequest, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProductCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(request.Id, cancellationToken, true);
            if(product != null)
            {
                _mapper.Map(request,product);
                await _unitOfWork.SaveAsync(cancellationToken);
            }

            return SuccessResult.Success(200);
        }
    }
}
