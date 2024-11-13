using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public interface IBroadcastGroupService
    {
        Task<IEnumerable<BroadcastGroup>> GetAllAccountAsync();
        Task<BroadcastGroup> GetRoleByIdAsync(int id);
        Task CreateRoleAsync(BroadcastGroup broadcastGroup);
        Task UpdateRoleAsync(BroadcastGroup broadcastGroup);
        Task DeleteRoleAsync(int id);
    }
}
