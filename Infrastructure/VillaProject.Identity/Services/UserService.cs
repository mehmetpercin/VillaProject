using Microsoft.AspNetCore.Identity;
using VillaProject.Application.Dtos.Identities;
using VillaProject.Application.Services;
using VillaProject.Domain.Exceptions;
using VillaProject.Identity.Entities;

namespace VillaProject.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> RegisterAsync(RegistrationRequest request, CancellationToken cancellationToken = default)
        {
            var user = new AppUser
            {
                Email = request.Email,
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();
                throw new IdentityException(string.Join(Environment.NewLine, errors));
            }

            return user.Id;
        }
    }
}
