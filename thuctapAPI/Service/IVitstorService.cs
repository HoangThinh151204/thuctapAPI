using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public interface IVitstorService
    {
        Task<IEnumerable<Visitor>> GetAllAccountAsync();
        Task<Visitor> GetRoleByIdAsync(int id);
        Task CreateRoleAsync(Visitor visitor);
        Task UpdateRoleAsync(Visitor visitor);
        Task DeleteRoleAsync(int id);
    }
}
