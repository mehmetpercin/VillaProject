using MediatR;
using VillaProject.Application.Dtos.Responses;

namespace VillaProject.Application.Features.Users.LoginCommand
{
    public class LoginCommandRequest : IRequest<Response>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
