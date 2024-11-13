using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public interface IBaselineService
    {
        Task<IEnumerable<Baseline>> GetAllAccountAsync();
        Task<Baseline> GetRoleByIdAsync(int id);
        Task CreateRoleAsync(Baseline baseline);
        Task UpdateRoleAsync(Baseline baseline);
        Task DeleteRoleAsync(int id);
    }
}
