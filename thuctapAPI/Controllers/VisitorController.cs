using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using thuctapAPI.Model;
using thuctapAPI.Service;

namespace thuctapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private readonly IVitstorService vitstorService;
        public VisitorController(IVitstorService accountService)
        {
            vitstorService = accountService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Visitor>>> GetRoles()
        {
            var visitors = await vitstorService.GetAllAccountAsync();
            return Ok(visitors);
        }
        // GET: api/roles/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Visitor>> GetRole(int id)
        {
            var visitor = await vitstorService.GetRoleByIdAsync(id);
            if (visitor == null)
            {
                return NotFound();
            }
            return Ok(visitor);
        }
        [HttpPost]
        public async Task<ActionResult<Visitor>> CreateRole(Visitor visitor)
        {
            await vitstorService.CreateRoleAsync(visitor);
            return CreatedAtAction(nameof(GetRole), new { id = visitor.IdVisitor }, visitor);
        }
        // PUT: api/roles/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, Visitor visitor)
        {
            if (id != visitor.IdVisitor)
            {
                return BadRequest();
            }

            await vitstorService.UpdateRoleAsync(visitor);
            return NoContent();
        }
        // DELETE: api/roles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await vitstorService.DeleteRoleAsync(id);
            return NoContent();
        }
    }
}
