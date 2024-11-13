using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using thuctapAPI.Model;
using thuctapAPI.Service;

namespace thuctapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetRoles()
        {
            var roles = await _accountService.GetAllAccountAsync();
            return Ok(roles);
        }
        // GET: api/roles/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetRole(int id)
        {
            var role = await _accountService.GetRoleByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }
        [HttpPost]
        public async Task<ActionResult<Account>> CreateRole(Account accounts)
        {
            await _accountService.CreateRoleAsync(accounts);
            return CreatedAtAction(nameof(GetRole), new { id = accounts.IdAcc }, accounts);
        }
        // PUT: api/roles/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, Account accounts)
        {
            if (id != accounts.IdAcc)
            {
                return BadRequest();
            }

            await _accountService.UpdateRoleAsync(accounts);
            return NoContent();
        }
        // DELETE: api/roles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await _accountService.DeleteRoleAsync(id);
            return NoContent();
        }
    }
}
