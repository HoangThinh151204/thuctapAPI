using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public interface IAnswerService
    {
        Task<IEnumerable<Answer>> GetAllAccountAsync();
        Task<Answer> GetRoleByIdAsync(int id);
        Task CreateRoleAsync(Answer answer);
        Task UpdateRoleAsync(Answer answer);
        Task DeleteRoleAsync(int id);
        
    }
}
