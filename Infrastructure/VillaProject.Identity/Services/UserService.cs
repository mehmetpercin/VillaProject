using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public async Task AddUserRoleAsync(string userId, string role, CancellationToken cancellationToken = default)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
                throw new DatabaseValidationException("User not found!");

            var identityResult = await _userManager.AddToRoleAsync(user, role);
            if (!identityResult.Succeeded)
            {
                var errors = identityResult.Errors.Select(x => x.Description).ToList();
                throw new IdentityException(string.Join(Environment.NewLine, errors));
            }
        }

        public async Task RemoveUserRoleAsync(string userId, string role, CancellationToken cancellationToken = default)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
                throw new DatabaseValidationException("User not found!");

            var identityResult = await _userManager.RemoveFromRoleAsync(user, role);
            if (!identityResult.Succeeded)
            {
                var errors = identityResult.Errors.Select(x => x.Description).ToList();
                throw new IdentityException(string.Join(Environment.NewLine, errors));
            }
        }

        public async Task<string> RegisterAsync(RegistrationDto request, CancellationToken cancellationToken = default)
        {
            var user = new AppUser
            {
                Email = request.Email,
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            var userExists = await _userManager.Users.AnyAsync(cancellationToken);

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();
                throw new IdentityException(string.Join(Environment.NewLine, errors));
            }

            if (!userExists)
                await AddUserRoleAsync(user.Id, "Admin", cancellationToken);

            return user.Id;
        }
    }
}
