using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using thuctapAPI.Model;
using thuctapAPI.Service;

namespace thuctapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BroadcastGroupController : ControllerBase
    {
        private readonly IBroadcastGroupService broadcastGroupService;
        public BroadcastGroupController(IBroadcastGroupService accountService)
        {
            broadcastGroupService = accountService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BroadcastGroup>>> GetRoles()
        {
            var broadcastGroups = await broadcastGroupService.GetAllAccountAsync();
            return Ok(broadcastGroups);
        }
        // GET: api/roles/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BroadcastGroup>> GetRole(int id)
        {
            var broadcastGroups = await broadcastGroupService.GetRoleByIdAsync(id);
            if (broadcastGroups == null)
            {
                return NotFound();
            }
            return Ok(broadcastGroups);
        }
        [HttpPost]
        public async Task<ActionResult<Baseline>> CreateRole(BroadcastGroup broadcastGroups)
        {
            await broadcastGroupService.CreateRoleAsync(broadcastGroups);
            return CreatedAtAction(nameof(GetRole), new { id = broadcastGroups.IdGroup }, broadcastGroups);
        }
        // PUT: api/roles/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, BroadcastGroup broadcastGroups)
        {
            if (id != broadcastGroups.IdGroup)
            {
                return BadRequest();
            }

            await broadcastGroupService.UpdateRoleAsync(broadcastGroups);
            return NoContent();
        }
        // DELETE: api/roles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await broadcastGroupService.DeleteRoleAsync(id);
            return NoContent();
        }
    }
}
