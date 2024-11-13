using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using thuctapAPI.Model;
using thuctapAPI.Service;

namespace thuctapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IPositionsService positionsService;
        public PositionsController(IPositionsService accountService)
        {
            positionsService = accountService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notification>>> GetRoles()
        {
            var positions = await positionsService.GetAllAccountAsync();
            return Ok(positions);
        }
        // GET: api/roles/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Position>> GetRole(int id)
        {
            var position = await positionsService.GetRoleByIdAsync(id);
            if (position == null)
            {
                return NotFound();
            }
            return Ok(position);
        }
        [HttpPost]
        public async Task<ActionResult<Position>> CreateRole(Position position)
        {
            await positionsService.CreateRoleAsync(position);
            return CreatedAtAction(nameof(GetRole), new { id = position.IdPos }, position);
        }
        // PUT: api/roles/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, Position position)
        {
            if (id != position.IdPos)
            {
                return BadRequest();
            }

            await positionsService.UpdateRoleAsync(position);
            return NoContent();
        }
        // DELETE: api/roles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await positionsService.DeleteRoleAsync(id);
            return NoContent();
        }
    }
}
