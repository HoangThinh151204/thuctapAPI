using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using thuctapAPI.Model;
using thuctapAPI.Service;

namespace thuctapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountNotificationController : ControllerBase
    {
        private readonly IAccountNotificationService _accountService;
        public AccountNotificationController(IAccountNotificationService accountNotification)
        {
            _accountService = accountNotification;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountNotification>>> GetRoles()
        {
            var accountNotification = await _accountService.GetAllAccountAsync();
            return Ok(accountNotification);
        }
        // GET: api/roles/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountNotification>> GetRole(int id)
        {
            var accountNotification = await _accountService.GetRoleByIdAsync(id);
            if (accountNotification == null)
            {
                return NotFound();
            }
            return Ok(accountNotification);
        }
        [HttpPost]
        public async Task<ActionResult<AccountNotification>> CreateRole(AccountNotification accountNotification)
        {
            await _accountService.CreateRoleAsync(accountNotification);
            return CreatedAtAction(nameof(GetRole), new { id = accountNotification.Id }, accountNotification);
        }
    }
}
