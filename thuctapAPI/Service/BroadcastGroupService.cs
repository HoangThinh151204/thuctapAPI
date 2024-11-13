using Microsoft.EntityFrameworkCore;
using thuctapAPI.Data;
using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public class BroadcastGroupService : IBroadcastGroupService
    {
        private readonly AppDbContext _context;

        public BroadcastGroupService(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateRoleAsync(BroadcastGroup broadcastGroup)
        {
            await _context.BroadcastGroups.AddAsync(broadcastGroup);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(int id)
        {
            var broadcastGroup = await _context.BroadcastGroups.FindAsync(id);
            if (broadcastGroup != null)
            {
                _context.BroadcastGroups.Remove(broadcastGroup);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BroadcastGroup>> GetAllAccountAsync()
        {
            return await _context.BroadcastGroups.ToListAsync();
        }

        public async Task<BroadcastGroup> GetRoleByIdAsync(int id)
        {
            return await _context.BroadcastGroups.FindAsync(id);
        }

        public async Task UpdateRoleAsync(BroadcastGroup broadcastGroup)
        {
            _context.BroadcastGroups.Update(broadcastGroup);
            await _context.SaveChangesAsync();
        }
    }
}
