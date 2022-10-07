using MediatR;
using VillaProject.Application.Dtos.Identities;
using VillaProject.Application.Dtos.Responses;

namespace VillaProject.Application.Features.Users.RefreshTokenLoginCommand
{
    public class RefreshTokenLoginCommandRequest : IRequest<Response<AuthResponse>>
    {
        public string RefreshToken { get; set; }
    }
}
