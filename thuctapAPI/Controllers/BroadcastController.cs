using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using thuctapAPI.Model;
using thuctapAPI.Service;

namespace thuctapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BroadcastController : ControllerBase
    {
        private readonly IBroadcastsService broadcastsService;
        public BroadcastController(IBroadcastsService accountService)
        {
            broadcastsService = accountService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Broadcast>>> GetRoles()
        {
            var broadcasts = await broadcastsService.GetAllAccountAsync();
            return Ok(broadcasts);
        }
        // GET: api/roles/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Broadcast>> GetRole(int id)
        {
            var broadcasts = await broadcastsService.GetRoleByIdAsync(id);
            if (broadcasts == null)
            {
                return NotFound();
            }
            return Ok(broadcasts);
        }
        [HttpPost]
        public async Task<ActionResult<Broadcast>> CreateRole(Broadcast broadcast)
        {
            await broadcastsService.CreateRoleAsync(broadcast);
            return CreatedAtAction(nameof(GetRole), new { id = broadcast.IdB }, broadcast);
        }
        // PUT: api/roles/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, Broadcast broadcast)
        {
            if (id != broadcast.IdGroup)
            {
                return BadRequest();
            }

            await broadcastsService.UpdateRoleAsync(broadcast);
            return NoContent();
        }
        // DELETE: api/roles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await broadcastsService.DeleteRoleAsync(id);
            return NoContent();
        }
    }
}
