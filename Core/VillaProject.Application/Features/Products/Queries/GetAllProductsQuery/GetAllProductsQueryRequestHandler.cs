using AutoMapper;
using MediatR;
using VillaProject.Application.Dtos.Products;
using VillaProject.Application.Dtos.Responses;
using VillaProject.Application.Repositories;

namespace VillaProject.Application.Features.Products.Queries.GetAllProductsQuery
{
    public class GetAllProductsQueryRequestHandler : IRequestHandler<GetAllProductsQueryRequest, Response>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await Task.Run(() =>
            {
                return _productRepository.GetAll(false).ToList();
            });

            var result = _mapper.Map<List<ProductListDto>>(products);
            return SuccessDataResponse.Success(result, 200);
        }
    }
}
