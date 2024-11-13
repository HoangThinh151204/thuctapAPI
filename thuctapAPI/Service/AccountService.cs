using Microsoft.EntityFrameworkCore;
using thuctapAPI.Data;
using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _context;

        public AccountService(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateRoleAsync(Account role)
        {
            await _context.Accounts.AddAsync(role);
            await _context.SaveChangesAsync();
        }

        public Task CreateRoleAsync(AccountSurveyRequest accounts)
        {
            throw new NotImplementedException();
        }

        public Task CreateRoleAsync(Answer account)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteRoleAsync(int id)
        {
            var role = await _context.Accounts.FindAsync(id);
            if (role != null)
            {
                _context.Accounts.Remove(role);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Account>> GetAllAccountAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account> GetRoleByIdAsync(int id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        public async Task UpdateRoleAsync(Account role)
        {
            _context.Accounts.Update(role);
            await _context.SaveChangesAsync();
        }

        public Task UpdateRoleAsync(AccountArea accounts)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRoleAsync(AccountSurveyRequest accounts)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRoleAsync(Answer accounts)
        {
            throw new NotImplementedException();
        }
    }
}
