using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using thuctapAPI.Model;
using thuctapAPI.Service;

namespace thuctapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobImageController : ControllerBase
    {
        private readonly IJobImageService jobImageService;
        public JobImageController(IJobImageService accountService)
        {
            jobImageService = accountService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Job>>> GetRoles()
        {
            var jobImages = await jobImageService.GetAllAccountAsync();
            return Ok(jobImages);
        }
        // GET: api/roles/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<JobImage>> GetRole(int id)
        {
            var jobImage = await jobImageService.GetRoleByIdAsync(id);
            if (jobImage == null)
            {
                return NotFound();
            }
            return Ok(jobImage);
        }
        [HttpPost]
        public async Task<ActionResult<JobImage>> CreateRole(JobImage jobImage)
        {
            await jobImageService.CreateRoleAsync(jobImage);
            return CreatedAtAction(nameof(GetRole), new { id = jobImage.IdImg }, jobImage);
        }
        // PUT: api/roles/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, JobImage jobImage)
        {
            if (id != jobImage.IdJob)
            {
                return BadRequest();
            }

            await jobImageService.UpdateRoleAsync(jobImage);
            return NoContent();
        }
        // DELETE: api/roles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await jobImageService.DeleteRoleAsync(id);
            return NoContent();
        }
    }
}
