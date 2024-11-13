using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using thuctapAPI.Model;
using thuctapAPI.Service;

namespace thuctapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaselineController : ControllerBase
    {
        private readonly IBaselineService baselineService;
        public BaselineController(IBaselineService accountService)
        {
            baselineService = accountService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Baseline>>> GetRoles()
        {
            var baselines = await baselineService.GetAllAccountAsync();
            return Ok(baselines);
        }
        // GET: api/roles/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Baseline>> GetRole(int id)
        {
            var baselines = await baselineService.GetRoleByIdAsync(id);
            if (baselines == null)
            {
                return NotFound();
            }
            return Ok(baselines);
        }
        [HttpPost]
        public async Task<ActionResult<Baseline>> CreateRole(Baseline baselines)
        {
            await baselineService.CreateRoleAsync(baselines);
            return CreatedAtAction(nameof(GetRole), new { id = baselines.IdJob }, baselines);
        }
        // PUT: api/roles/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, Baseline baseline)
        {
            if (id != baseline.IdJob)
            {
                return BadRequest();
            }

            await baselineService.UpdateRoleAsync(baseline);
            return NoContent();
        }
        // DELETE: api/roles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await baselineService.DeleteRoleAsync(id);
            return NoContent();
        }
    }
}
