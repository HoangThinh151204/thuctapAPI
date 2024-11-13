using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public interface IAccountSurveyRequestService
    {
        Task<IEnumerable<AccountSurveyRequest>> GetAllAccountAsync();
        Task<AccountSurveyRequest> GetRoleByIdAsync(int id);
        Task CreateRoleAsync(AccountSurveyRequest accountSurveyRequest);
        Task UpdateRoleAsync(AccountSurveyRequest accountSurveyRequest);
        Task DeleteRoleAsync(int id);
    }
}
