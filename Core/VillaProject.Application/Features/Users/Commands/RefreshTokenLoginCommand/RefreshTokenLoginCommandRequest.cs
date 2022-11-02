using MediatR;
using VillaProject.Application.Dtos.Responses;

namespace VillaProject.Application.Features.Users.RefreshTokenLoginCommand
{
    public class RefreshTokenLoginCommandRequest : IRequest<Result>
    {
        public string RefreshToken { get; set; }
    }
}
