using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using thuctapAPI.Model;
using thuctapAPI.Service;

namespace thuctapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehoueController : ControllerBase
    {
        private readonly IWarehouseService warehouseService;
        public WarehoueController(IWarehouseService accountService)
        {
            warehouseService = accountService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Warehouse>>> GetRoles()
        {
            var warehouses = await warehouseService.GetAllAccountAsync();
            return Ok(warehouses);
        }
        // GET: api/roles/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Warehouse>> GetRole(int id)
        {
            var warehouse = await warehouseService.GetRoleByIdAsync(id);
            if (warehouse == null)
            {
                return NotFound();
            }
            return Ok(warehouse);
        }
        [HttpPost]
        public async Task<ActionResult<Warehouse>> CreateRole(Warehouse warehouse)
        {
            await warehouseService.CreateRoleAsync(warehouse);
            return CreatedAtAction(nameof(GetRole), new { id = warehouse.IdWS }, warehouse);
        }
        // PUT: api/roles/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, Warehouse warehouse)
        {
            if (id != warehouse.IdWS)
            {
                return BadRequest();
            }

            await warehouseService.UpdateRoleAsync(warehouse);
            return NoContent();
        }
        // DELETE: api/roles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await warehouseService.DeleteRoleAsync(id);
            return NoContent();
        }
    }
}
