using Microsoft.EntityFrameworkCore;
using thuctapAPI.Data;
using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public class AreaSercive : IAreaService
    {
        private readonly AppDbContext _context;

        public AreaSercive(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateRoleAsync(Area area)
        {
            await _context.Areas.AddAsync(area);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(int id)
        {
            var area = await _context.Areas.FindAsync(id);
            if (area != null)
            {
                _context.Areas.Remove(area);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Area>> GetAllAccountAsync()
        {
            return await _context.Areas.ToListAsync();
        }

        public async Task<Area> GetRoleByIdAsync(int id)
        {
            return await _context.Areas.FindAsync(id);
        }

        public async Task UpdateRoleAsync(Area area)
        {
            _context.Areas.Update(area);
            await _context.SaveChangesAsync();
        }
    }
}
