using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public interface IArticleService
    {
        Task<IEnumerable<Article>> GetAllAccountAsync();
        Task<Article> GetRoleByIdAsync(int id);
        Task CreateRoleAsync(Article article);
        Task UpdateRoleAsync(Article article);
        Task DeleteRoleAsync(int id);
    }
}
