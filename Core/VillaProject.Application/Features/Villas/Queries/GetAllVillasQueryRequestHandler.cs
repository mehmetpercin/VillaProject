using MediatR;
using VillaProject.Application.Dtos.Responses;
using VillaProject.Application.Repositories;

namespace VillaProject.Application.Features.Villas.Queries
{
    public class GetAllVillasQueryRequestHandler : IRequestHandler<GetAllVillasQueryRequest, Response<List<GetAllVillasResponse>>>
    {
        private readonly IVillaRepository _villaRepository;

        public GetAllVillasQueryRequestHandler(IVillaRepository villaRepository)
        {
            _villaRepository = villaRepository;
        }

        public async Task<Response<List<GetAllVillasResponse>>> Handle(GetAllVillasQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await Task.Run(() =>
            {
                return _villaRepository.GetAll(false).Select(x => new GetAllVillasResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToList();
            }, cancellationToken);

            return SuccessDataResponse<List<GetAllVillasResponse>>.Success(result, 200);
        }
    }
}
