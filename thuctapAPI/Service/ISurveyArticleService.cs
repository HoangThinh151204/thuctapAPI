using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public interface ISurveyArticleService
    {
        Task<IEnumerable<SurveyArticle>> GetAllAccountAsync();
        Task<SurveyArticle> GetRoleByIdAsync(int id);
        Task CreateRoleAsync(SurveyArticle surveyArticle);
        Task UpdateRoleAsync(SurveyArticle surveyArticle);
        Task DeleteRoleAsync(int id);
    }
}
