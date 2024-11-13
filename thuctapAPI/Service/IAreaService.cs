using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public interface IAreaService
    {
        Task<IEnumerable<Area>> GetAllAccountAsync();
        Task<Area> GetRoleByIdAsync(int id);
        Task CreateRoleAsync(Area area);
        Task UpdateRoleAsync(Area area);
        Task DeleteRoleAsync(int id);
    }
}
