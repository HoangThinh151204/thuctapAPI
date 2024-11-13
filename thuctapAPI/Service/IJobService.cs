using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public interface IJobService
    {
        Task<IEnumerable<Job>> GetAllAccountAsync();
        Task<Job> GetRoleByIdAsync(int id);
        Task CreateRoleAsync(Job job);
        Task UpdateRoleAsync(Job job);
        Task DeleteRoleAsync(int id);
    }
}
