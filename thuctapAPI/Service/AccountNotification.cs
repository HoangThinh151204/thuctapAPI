using Microsoft.EntityFrameworkCore;
using thuctapAPI.Data;
using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public class AccountNotificationService : IAccountNotificationService
    {
        private readonly AppDbContext _context;

        public AccountNotificationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateRoleAsync(thuctapAPI.Model.AccountNotification accountNotification)
        {
            await _context.AccountNotifications.AddAsync(accountNotification);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(int id)
        {
            var accountNotification = await _context.AccountNotifications.FindAsync(id);
            if (accountNotification != null)
            {
                _context.AccountNotifications.Remove(accountNotification);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<thuctapAPI.Model.AccountNotification>> GetAllAccountAsync()
        {
            return await _context.AccountNotifications.ToListAsync();
        }

        public async Task<thuctapAPI.Model.AccountNotification> GetRoleByIdAsync(int id)
        {
            return await _context.AccountNotifications.FindAsync(id);
        }

        public async Task UpdateRoleAsync(thuctapAPI.Model.AccountNotification accountNotification)
        {
            _context.AccountNotifications.Update(accountNotification);
            await _context.SaveChangesAsync();
        }
    }
}
