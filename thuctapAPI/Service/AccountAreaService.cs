using Microsoft.EntityFrameworkCore;
using System.Data;
using thuctapAPI.Data;
using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public class AccountAreaService : IAccountAreaService
    {
        private readonly AppDbContext _context;

        public AccountAreaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateRoleAsync(AccountArea accountArea)
        {
            await _context.AccountAreas.AddAsync(accountArea);
            await _context.SaveChangesAsync();
        }

        public Task CreateRoleAsync(Account accountArea)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteRoleAsync(int id)
        {
            var accountArea = await _context.AccountAreas.FindAsync(id);
            if (accountArea != null)
            {
                _context.AccountAreas.Remove(accountArea);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AccountArea>> GetAllAccountAsync()
        {
            return await _context.AccountAreas.ToListAsync();
        }

        public async Task<AccountArea> GetRoleByIdAsync(int id)
        {
            return await _context.AccountAreas.FindAsync(id);
        }

        public async Task UpdateRoleAsync(AccountArea accountArea)
        {
            _context.AccountAreas.Update(accountArea);
            await _context.SaveChangesAsync();
        }
    }
}
