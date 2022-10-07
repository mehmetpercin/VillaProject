using VillaProject.Application.Dtos.Roles;

namespace VillaProject.Application.Services
{
    public interface IRoleService
    {
        Task<List<RoleDto>> GetUserRolesAsync();
        Task<string> AddUserRoleAsync(string roleName);
        Task UpdateUserRoleAsync(RoleDto roleDto);
        Task DeleteUserRoleAsync(string roleName);
    }
}
