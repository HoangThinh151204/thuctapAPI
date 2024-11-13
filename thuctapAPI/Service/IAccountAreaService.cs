using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public interface IAccountAreaService
    {
        Task<IEnumerable<AccountArea>> GetAllAccountAsync();
        Task<AccountArea> GetRoleByIdAsync(int id);
        Task CreateRoleAsync(AccountArea accountArea);
        Task UpdateRoleAsync(AccountArea accountArea);
        Task DeleteRoleAsync(int id);
        Task CreateRoleAsync(Account accountArea);
    }
}
