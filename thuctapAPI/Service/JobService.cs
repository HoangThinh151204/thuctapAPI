using Microsoft.EntityFrameworkCore;
using thuctapAPI.Data;
using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public class JobService : IJobService
    {
        private readonly AppDbContext _context;

        public JobService(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateRoleAsync(Job job)
        {
            await _context.Jobs.AddAsync(job);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(int id)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job != null)
            {
                _context.Jobs.Remove(job);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Job>> GetAllAccountAsync()
        {
            return await _context.Jobs.ToListAsync();
        }

        public async Task<Job> GetRoleByIdAsync(int id)
        {
            return await _context.Jobs.FindAsync(id);
        }

        public async Task UpdateRoleAsync(Job job)
        {
            _context.Jobs.Update(job);
            await _context.SaveChangesAsync();
        }
    }
}
