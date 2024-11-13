using Microsoft.EntityFrameworkCore;
using thuctapAPI.Data;
using thuctapAPI.Model;

namespace thuctapAPI.Service
{
    public class SurveyRequestService : ISurveyRequestsService
    {
        private readonly AppDbContext _context;

        public SurveyRequestService(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateRoleAsync(SurveyRequest surveyRequest)
        {
            await _context.SurveyRequests.AddAsync(surveyRequest);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(int id)
        {
            var SurveyRequests = await _context.SurveyRequests.FindAsync(id);
            if (SurveyRequests != null)
            {
                _context.SurveyRequests.Remove(SurveyRequests);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SurveyRequest>> GetAllAccountAsync()
        {
            return await _context.SurveyRequests.ToListAsync();
        }

        public async Task<SurveyRequest> GetRoleByIdAsync(int id)
        {
            return await _context.SurveyRequests.FindAsync(id);
        }

        public async Task UpdateRoleAsync(SurveyRequest surveyRequest)
        {
            _context.SurveyRequests.Update(surveyRequest);
            await _context.SaveChangesAsync();
        }
    }
}
