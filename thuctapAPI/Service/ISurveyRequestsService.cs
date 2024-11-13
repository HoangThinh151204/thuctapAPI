using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public interface ISurveyRequestsService
    {
        Task<IEnumerable<SurveyRequest>> GetAllAccountAsync();
        Task<SurveyRequest> GetRoleByIdAsync(int id);
        Task CreateRoleAsync(SurveyRequest surveyRequest);
        Task UpdateRoleAsync(SurveyRequest surveyRequest);
        Task DeleteRoleAsync(int id);
    }
}
