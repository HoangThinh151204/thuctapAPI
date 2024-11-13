using Microsoft.EntityFrameworkCore;
using thuctapAPI.Data;
using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public class PositionsService : IPositionsService
    {
        private readonly AppDbContext _context;

        public PositionsService(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateRoleAsync(Position position)
        {
            await _context.Positions.AddAsync(position);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(int id)
        {
            var position = await _context.Positions.FindAsync(id);
            if (position != null)
            {
                _context.Positions.Remove(position);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Position>> GetAllAccountAsync()
        {
            return await _context.Positions.ToListAsync();
        }

        public async Task<Position> GetRoleByIdAsync(int id)
        {
            return await _context.Positions.FindAsync(id);
        }

        public async Task UpdateRoleAsync(Position position)
        {
            _context.Positions.Update(position);
            await _context.SaveChangesAsync();
        }
    }
}
