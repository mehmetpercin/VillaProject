using MediatR;
using VillaProject.Application.Dtos.Identities;
using VillaProject.Application.Dtos.Responses;
using VillaProject.Application.Services;

namespace VillaProject.Application.Features.Users.LoginCommand
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, Result>
    {
        private readonly IAuthService _authService;

        public LoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<Result> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _authService.LoginAsync(new AuthDto
            {
                Email = request.Email,
                Password = request.Password
            }, cancellationToken);

            return SuccessDataResult.Success(result, 200);
        }
    }
}
