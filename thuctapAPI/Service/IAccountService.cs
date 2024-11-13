using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAllAccountAsync();
        Task<Account> GetRoleByIdAsync(int id);
        Task CreateRoleAsync(Account role);
        Task UpdateRoleAsync(Account role);
        Task DeleteRoleAsync(int id);
        Task UpdateRoleAsync(AccountArea accounts);
        Task UpdateRoleAsync(AccountSurveyRequest accounts);
        Task CreateRoleAsync(AccountSurveyRequest accounts);
        Task CreateRoleAsync(Answer account);
        Task UpdateRoleAsync(Answer accounts);
    };
}
