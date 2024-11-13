using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public interface IAccountNotificationService
    {
        Task<IEnumerable<AccountNotification>> GetAllAccountAsync();
        Task<AccountNotification> GetRoleByIdAsync(int id);
        Task CreateRoleAsync(AccountNotification accountNotification);
        Task UpdateRoleAsync(AccountNotification accountNotification);
        Task DeleteRoleAsync(int id);
        
    }
}
