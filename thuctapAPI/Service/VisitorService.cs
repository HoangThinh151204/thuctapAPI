using Microsoft.EntityFrameworkCore;
using thuctapAPI.Data;
using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public class VisitorService : IVitstorService
    {
        private readonly AppDbContext _context;

        public VisitorService(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateRoleAsync(Visitor visitor)
        {
            await _context.Visitors.AddAsync(visitor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(int id)
        {
            var visitor = await _context.Visitors.FindAsync(id);
            if (visitor != null)
            {
                _context.Visitors.Remove(visitor);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Visitor>> GetAllAccountAsync()
        {
            return await _context.Visitors.ToListAsync();
        }

        public async Task<Visitor> GetRoleByIdAsync(int id)
        {
            return await _context.Visitors.FindAsync(id);
        }

        public async Task UpdateRoleAsync(Visitor visitor)
        {
            _context.Visitors.Update(visitor);
            await _context.SaveChangesAsync();
        }
    }
}
