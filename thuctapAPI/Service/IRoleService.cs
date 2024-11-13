using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAllAccountAsync();
        Task<Role> GetRoleByIdAsync(int id);
        Task CreateRoleAsync(Role role);
        Task UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(int id);
    }
}
