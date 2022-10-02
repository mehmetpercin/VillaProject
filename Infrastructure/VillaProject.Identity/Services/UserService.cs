using VillaProject.Application.Dtos.Identities;
using VillaProject.Application.Services;

namespace VillaProject.Identity.Services
{
    public class UserService : IUserService
    {
        public Task<string> RegisterAsync(RegistrationRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
