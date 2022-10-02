using VillaProject.Application.Dtos.Identities;

namespace VillaProject.Application.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> LoginAsync(AuthRequest request, CancellationToken cancellationToken = default);
        Task<AuthResponse> LoginWithRefreshTokenAsync(string refreshToken, CancellationToken cancellationToken = default);
    }
}
