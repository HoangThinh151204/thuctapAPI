using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using thuctapAPI.Model;
using thuctapAPI.Service;

namespace thuctapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountSurveRequestController : ControllerBase
    {
        private readonly IAccountSurveyRequestService _accountService;
        public AccountSurveRequestController(IAccountSurveyRequestService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountSurveyRequest>>> GetRoles()
        {
            var accountSurveyRequest = await _accountService.GetAllAccountAsync();
            return Ok(accountSurveyRequest);
        }
        // GET: api/roles/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountSurveyRequest>> GetRole(int id)
        {
            var accountSurveyRequest = await _accountService.GetRoleByIdAsync(id);
            if (accountSurveyRequest == null)
            {
                return NotFound();
            }
            return Ok(accountSurveyRequest);
        }
        [HttpPost]
        public async Task<ActionResult<AccountSurveyRequest>> CreateRole(AccountSurveyRequest accountSurveyRequest)
        {
            await _accountService.CreateRoleAsync(accountSurveyRequest);
            return CreatedAtAction(nameof(GetRole), new { id = accountSurveyRequest.IdAcc , accountSurveyRequest.IdSR}, accountSurveyRequest);
        }
       
       
    }
}
