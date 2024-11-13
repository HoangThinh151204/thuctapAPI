using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using thuctapAPI.Model;
using thuctapAPI.Service;

namespace thuctapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IAreaService areaService;
        public AreaController(IAreaService accountService)
        {
            areaService = accountService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Area>>> GetRoles()
        {
            var area = await areaService.GetAllAccountAsync();
            return Ok(area);
        }
        // GET: api/roles/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Area>> GetRole(int id)
        {
            var area = await areaService.GetRoleByIdAsync(id);
            if (area == null)
            {
                return NotFound();
            }
            return Ok(area);
        }
        [HttpPost]
        public async Task<ActionResult<Area>> CreateRole(Area area)
        {
            await areaService.CreateRoleAsync(area);
            return CreatedAtAction(nameof(GetRole), new { id = area.IdArea }, area);
        }
        // PUT: api/roles/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, Area area)
        {
            if (id != area.IdArea)
            {
                return BadRequest();
            }

            await areaService.UpdateRoleAsync(area);
            return NoContent();
        }
        // DELETE: api/roles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await areaService.DeleteRoleAsync(id);
            return NoContent();
        }
    }
}
