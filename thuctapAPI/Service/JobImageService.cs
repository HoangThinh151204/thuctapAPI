using Microsoft.EntityFrameworkCore;
using thuctapAPI.Data;
using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public class JobImageService : IJobImageService
    {
        private readonly AppDbContext _context;

        public JobImageService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateRoleAsync(JobImage jobImage)
        {
            await _context.JobImages.AddAsync(jobImage);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(int id)
        {
            var jobImage = await _context.JobImages.FindAsync(id);
            if (jobImage != null)
            {
                _context.JobImages.Remove(jobImage);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<JobImage>> GetAllAccountAsync()
        {
            return await _context.JobImages.ToListAsync();
        }

        public async Task<JobImage> GetRoleByIdAsync(int id)
        {
            return await _context.JobImages.FindAsync(id);
        }

        public async Task UpdateRoleAsync(JobImage jobImage)
        {
            _context.JobImages.Update(jobImage);
            await _context.SaveChangesAsync();
        }
    }
}
