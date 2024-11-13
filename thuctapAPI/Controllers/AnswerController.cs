using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using thuctapAPI.Model;
using thuctapAPI.Service;

namespace thuctapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _accountService;
        public AnswerController(IAnswerService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Answer>>> GetRoles()
        {
            var answer = await _accountService.GetAllAccountAsync();
            return Ok(answer);
        }
        // GET: api/roles/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Answer>> GetRole(int id)
        {
            var answer = await _accountService.GetRoleByIdAsync(id);
            if (answer == null)
            {
                return NotFound();
            }
            return Ok(answer);
        }
        [HttpPost]
        public async Task<ActionResult<Answer>> CreateRole(Answer answer)
        {
            await _accountService.CreateRoleAsync(answer);
            return CreatedAtAction(nameof(GetRole), new { id = answer.IdAnswer }, answer);
        }
        // PUT: api/roles/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, Answer answer)
        {
            if (id != answer.IdAnswer)
            {
                return BadRequest();
            }

            await _accountService.UpdateRoleAsync(answer);
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
