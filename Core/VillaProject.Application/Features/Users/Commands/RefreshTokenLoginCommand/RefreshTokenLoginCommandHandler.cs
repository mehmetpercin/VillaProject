using MediatR;
using VillaProject.Application.Dtos.Identities;
using VillaProject.Application.Dtos.Responses;
using VillaProject.Application.Services;

namespace VillaProject.Application.Features.Users.RefreshTokenLoginCommand
{
    public class RefreshTokenLoginCommandHandler : IRequestHandler<RefreshTokenLoginCommandRequest, Response<AuthResponse>>
    {
        private readonly IAuthService _authService;

        public RefreshTokenLoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<Response<AuthResponse>> Handle(RefreshTokenLoginCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _authService.LoginWithRefreshTokenAsync(request.RefreshToken, cancellationToken);
            return SuccessDataResponse<AuthResponse>.Success(result, 200);
        }
    }
}
