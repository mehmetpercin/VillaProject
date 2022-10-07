using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VillaProject.Application.Dtos.Roles;
using VillaProject.Application.Services;
using VillaProject.Domain.Exceptions;

namespace VillaProject.Identity.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<string> AddUserRoleAsync(string roleName)
        {
            var exists = await _roleManager.RoleExistsAsync(roleName);
            if (exists)
                throw new DatabaseValidationException("Role already exists!");

            var identityRole = new IdentityRole { Name = roleName };
            var result = await _roleManager.CreateAsync(identityRole);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();
                throw new Exception(string.Join(Environment.NewLine, errors));
            }

            return identityRole.Id;
        }

        public async Task DeleteUserRoleAsync(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role is null)
                return;

            var identiyResult = await _roleManager.DeleteAsync(role);
            if (!identiyResult.Succeeded)
            {
                var errors = identiyResult.Errors.Select(x => x.Description).ToList();
                throw new IdentityException(string.Join(Environment.NewLine, errors));
            }
        }

        public async Task<List<RoleDto>> GetUserRolesAsync()
        {
            var roles = await _roleManager.Roles.Select(x =>
                new RoleDto
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();

            return roles;
        }

        public async Task UpdateUserRoleAsync(RoleDto roleDto)
        {
            var role = await _roleManager.FindByIdAsync(roleDto.Id);
            if (role is null)
                return;

            role.Name = roleDto.Name;
            var identiyResult = await _roleManager.UpdateAsync(role);
            if (!identiyResult.Succeeded)
            {
                var errors = identiyResult.Errors.Select(x => x.Description).ToList();
                throw new IdentityException(string.Join(Environment.NewLine, errors));
            }
        }
    }
}
