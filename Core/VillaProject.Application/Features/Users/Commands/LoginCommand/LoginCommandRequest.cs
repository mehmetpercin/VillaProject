using MediatR;
using VillaProject.Application.Dtos.Identities;
using VillaProject.Application.Dtos.Responses;

namespace VillaProject.Application.Features.Users.LoginCommand
{
    public class LoginCommandRequest : IRequest<Response<AuthResponse>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
