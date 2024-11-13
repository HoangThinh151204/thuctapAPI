using Microsoft.EntityFrameworkCore;
using thuctapAPI.Data;
using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public class ArticleService : IArticleService
    {
        private readonly AppDbContext _context;

        public ArticleService(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateRoleAsync(Article article)
        {
            await _context.Articles.AddAsync(article);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article != null)
            {
                _context.Articles.Remove(article);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Article>> GetAllAccountAsync()
        {
            return await _context.Articles.ToListAsync();
        }

        public async Task<Article> GetRoleByIdAsync(int id)
        {
            return await _context.Articles.FindAsync(id);
        }

        public async Task UpdateRoleAsync(Article article)
        {
            _context.Articles.Update(article);
            await _context.SaveChangesAsync();
        }
    }
}
