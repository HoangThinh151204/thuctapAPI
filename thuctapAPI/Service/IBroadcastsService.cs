using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public interface IBroadcastsService
    {
        Task<IEnumerable<Broadcast>> GetAllAccountAsync();
        Task<Broadcast> GetRoleByIdAsync(int id);
        Task CreateRoleAsync(Broadcast broadcast);
        Task UpdateRoleAsync(Broadcast broadcast);
        Task DeleteRoleAsync(int id);
    }
}
