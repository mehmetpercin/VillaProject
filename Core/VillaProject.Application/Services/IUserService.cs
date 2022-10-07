using VillaProject.Application.Dtos.Identities;

namespace VillaProject.Application.Services
{
    public interface IUserService
    {
        Task<string> RegisterAsync(RegistrationDto request, CancellationToken cancellationToken = default);
    }
}
