using MediatR;
using VillaProject.Application.Dtos.Responses;

namespace VillaProject.Application.Features.Villas.Queries
{
    public class GetAllVillasQueryRequest : IRequest<Response<List<GetAllVillasResponse>>>
    {
    }
}
