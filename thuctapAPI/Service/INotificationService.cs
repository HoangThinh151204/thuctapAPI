using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public interface INotificationService
    {
        Task<IEnumerable<Notification>> GetAllAccountAsync();
        Task<Notification> GetRoleByIdAsync(int id);
        Task CreateRoleAsync(Notification notification);
        Task UpdateRoleAsync(Notification notification);
        Task DeleteRoleAsync(int id);
    }
}
