using Microsoft.EntityFrameworkCore;
using thuctapAPI.Data;
using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public class BroadcastService : IBroadcastsService
    {
        private readonly AppDbContext _context;

        public BroadcastService(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateRoleAsync(Broadcast broadcast)
        {
            await _context.Broadcasts.AddAsync(broadcast);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(int id)
        {
            var broadcast = await _context.Broadcasts.FindAsync(id);
            if (broadcast != null)
            {
                _context.Broadcasts.Remove(broadcast);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Broadcast>> GetAllAccountAsync()
        {
            return await _context.Broadcasts.ToListAsync();
        }

        public async Task<Broadcast> GetRoleByIdAsync(int id)
        {
            return await _context.Broadcasts.FindAsync(id);
        }

        public async Task UpdateRoleAsync(Broadcast broadcast)
        {
            _context.Broadcasts.Update(broadcast);
            await _context.SaveChangesAsync();
        }
    }
}
