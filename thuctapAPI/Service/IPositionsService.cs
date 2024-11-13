using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public interface IPositionsService
    {
        Task<IEnumerable<Position>> GetAllAccountAsync();
        Task<Position> GetRoleByIdAsync(int id);
        Task CreateRoleAsync(Position position);
        Task UpdateRoleAsync(Position position);
        Task DeleteRoleAsync(int id);
    }
}
