using Microsoft.EntityFrameworkCore;
using System.Data;
using thuctapAPI.Data;
using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public class SurveyArticleService : ISurveyArticleService
    {
        private readonly AppDbContext _context;

        public SurveyArticleService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateRoleAsync(SurveyArticle surveyArticle)
        {
            await _context.SurveyArticles.AddAsync(surveyArticle);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(int id)
        {
            var surveyArticle = await _context.SurveyArticles.FindAsync(id);
            if (surveyArticle != null)
            {
                _context.SurveyArticles.Remove(surveyArticle);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SurveyArticle>> GetAllAccountAsync()
        {
            return await _context.SurveyArticles.ToListAsync();
        }

        public async Task<SurveyArticle> GetRoleByIdAsync(int id)
        {
            return await _context.SurveyArticles.FindAsync(id);
        }

        public async Task UpdateRoleAsync(SurveyArticle surveyArticle)
        {
            _context.SurveyArticles.Update(surveyArticle);
            await _context.SaveChangesAsync();
        }
    }
}
