using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public interface IQuestionsService
    {
        Task<IEnumerable<Question>> GetAllAccountAsync();
        Task<Question> GetRoleByIdAsync(int id);
        Task CreateRoleAsync(Question question);
        Task UpdateRoleAsync(Question question);
        Task DeleteRoleAsync(int id);
    }
}
