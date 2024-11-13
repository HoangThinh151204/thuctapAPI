using Microsoft.EntityFrameworkCore;
using System.Data;
using thuctapAPI.Data;
using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public class AnswerService : IAnswerService
    {
        private readonly AppDbContext _context;

        public AnswerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateRoleAsync(Answer answer)
        {
            await _context.Answers.AddAsync(answer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(int id)
        {
            var answer = await _context.Answers.FindAsync(id);
            if (answer != null)
            {
                _context.Answers.Remove(answer);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Answer>> GetAllAccountAsync()
        {
            return await _context.Answers.ToListAsync();
        }

        public async Task<Answer> GetRoleByIdAsync(int id)
        {
            return await _context.Answers.FindAsync(id);
        }

        public async Task UpdateRoleAsync(Answer answer)
        {
            _context.Answers.Update(answer);
            await _context.SaveChangesAsync();
        }
    }
}
