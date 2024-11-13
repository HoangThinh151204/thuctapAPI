using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using thuctapAPI.Model;
using thuctapAPI.Service;

namespace thuctapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountAreaController : ControllerBase
    {
        private readonly IAccountAreaService _accountService;

        public AccountAreaController(IAccountAreaService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountArea>>> GetRoles()
        {
            var accountAreas = await _accountService.GetAllAccountAsync();
            return Ok(accountAreas);
        }
        // GET: api/roles/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountArea>> GetRole(int id)
        {
            var accountAreas = await _accountService.GetRoleByIdAsync(id);
            if (accountAreas == null)
            {
                return NotFound();
            }
            return Ok(accountAreas);
        }
        [HttpPost]
        public async Task<ActionResult<AccountArea>> CreateRole(AccountArea accountArea)
        {
            await _accountService.CreateRoleAsync(accountArea);
            return CreatedAtAction(nameof(GetRole), new { id = accountArea.IdAcc}, accountArea);
        }        
       
    }
}
