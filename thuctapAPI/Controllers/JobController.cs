using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using thuctapAPI.Model;
using thuctapAPI.Service;

namespace thuctapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService jobService;
        public JobController(IJobService accountService)
        {
            jobService = accountService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Job>>> GetRoles()
        {
            var jobs = await jobService.GetAllAccountAsync();
            return Ok(jobs);
        }
        // GET: api/roles/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Job>> GetRole(int id)
        {
            var job = await jobService.GetRoleByIdAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            return Ok(job);
        }
        [HttpPost]
        public async Task<ActionResult<Job>> CreateRole(Job job)
        {
            await jobService.CreateRoleAsync(job);
            return CreatedAtAction(nameof(GetRole), new { id = job.IdJob }, job);
        }
        // PUT: api/roles/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, Job job)
        {
            if (id != job.IdJob)
            {
                return BadRequest();
            }

            await jobService.UpdateRoleAsync(job);
            return NoContent();
        }
        // DELETE: api/roles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await jobService.DeleteRoleAsync(id);
            return NoContent();
        }
    }
}
