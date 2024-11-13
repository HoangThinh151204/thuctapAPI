using Microsoft.EntityFrameworkCore;
using thuctapAPI.Data;
using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public class BaselineService : IBaselineService
    {
        private readonly AppDbContext _context;

        public BaselineService(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateRoleAsync(Baseline baseline)
        {
            await _context.Baselines.AddAsync(baseline);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(int id)
        {
            var baseline = await _context.Baselines.FindAsync(id);
            if (baseline != null)
            {
                _context.Baselines.Remove(baseline);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Baseline>> GetAllAccountAsync()
        {
            return await _context.Baselines.ToListAsync();
        }

        public async Task<Baseline> GetRoleByIdAsync(int id)
        {
            return await _context.Baselines.FindAsync(id);
        }

        public async Task UpdateRoleAsync(Baseline baseline)
        {
            _context.Baselines.Update(baseline);
            await _context.SaveChangesAsync();
        }
    }
}
