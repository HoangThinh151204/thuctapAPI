using thuctapAPI.Data;
using thuctapAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace thuctapAPI.Service
{
    public class AccountSurveyRequestService : IAccountSurveyRequestService
    {
        private readonly AppDbContext _context;

        public AccountSurveyRequestService(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateRoleAsync(AccountSurveyRequest accountSurveyRequest)
        {
            await _context.AccountSurveyRequests.AddAsync(accountSurveyRequest);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(int id)
        {
            var accountSurveyRequest = await _context.AccountSurveyRequests.FindAsync(id);
            if (accountSurveyRequest != null)
            {
                _context.AccountSurveyRequests.Remove(accountSurveyRequest);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AccountSurveyRequest>> GetAllAccountAsync()
        {
            return await _context.AccountSurveyRequests.ToListAsync();
        }

        public async Task<AccountSurveyRequest> GetRoleByIdAsync(int id)
        {
            return await _context.AccountSurveyRequests.FindAsync(id);
        }

        public async Task UpdateRoleAsync(AccountSurveyRequest accountSurveyRequest)
        {
            _context.AccountSurveyRequests.Update(accountSurveyRequest);
            await _context.SaveChangesAsync();
        }
    }
}
