using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public interface IWarehouseService
    {
        Task<IEnumerable<Warehouse>> GetAllAccountAsync();
        Task<Warehouse> GetRoleByIdAsync(int id);
        Task CreateRoleAsync(Warehouse warehouse);
        Task UpdateRoleAsync(Warehouse warehouse);
        Task DeleteRoleAsync(int id);
    }
}
