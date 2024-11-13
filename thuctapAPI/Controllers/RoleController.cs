using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using thuctapAPI.Model;
using thuctapAPI.Service;

namespace thuctapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;
        public RoleController(IRoleService accountService)
        {
            roleService = accountService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            var roles= await roleService.GetAllAccountAsync();
            return Ok(roles);
        }
        // GET: api/roles/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            var role = await roleService.GetRoleByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }
        [HttpPost]
        public async Task<ActionResult<Role>> CreateRole(Role role)
        {
            await roleService.CreateRoleAsync(role);
            return CreatedAtAction(nameof(GetRole), new { id = role.IdRole }, role);
        }
        // PUT: api/roles/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, Role role)
        {
            if (id != role.IdRole)
            {
                return BadRequest();
            }

            await roleService.UpdateRoleAsync(role);
            return NoContent();
        }
        // DELETE: api/roles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await roleService.DeleteRoleAsync(id);
            return NoContent();
        }
    }
}
