using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public interface IJobImageService
    {
        Task<IEnumerable<JobImage>> GetAllAccountAsync();
        Task<JobImage> GetRoleByIdAsync(int id);
        Task CreateRoleAsync(JobImage jobImage);
        Task UpdateRoleAsync(JobImage jobImage);
        Task DeleteRoleAsync(int id);
    }
}
