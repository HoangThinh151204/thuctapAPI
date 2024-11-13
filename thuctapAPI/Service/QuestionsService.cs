using Microsoft.EntityFrameworkCore;
using thuctapAPI.Data;
using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public class QuestionsService : IQuestionsService
    {
        private readonly AppDbContext _context;

        public QuestionsService(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateRoleAsync(Question question)
        {
            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question != null)
            {
                _context.Questions.Remove(question);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Question>> GetAllAccountAsync()
        {
            return await _context.Questions.ToListAsync();
        }

        public async Task<Question> GetRoleByIdAsync(int id)
        {
            return await _context.Questions.FindAsync(id);
        }

        public async Task UpdateRoleAsync(Question question)
        {
            _context.Questions.Update(question);
            await _context.SaveChangesAsync();
        }
    }
}
