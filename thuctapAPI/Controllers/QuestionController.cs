using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using thuctapAPI.Model;
using thuctapAPI.Service;

namespace thuctapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionsService questionsService;
        public QuestionController(IQuestionsService accountService)
        {
            questionsService = accountService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetRoles()
        {
            var questions = await questionsService.GetAllAccountAsync();
            return Ok(questions);
        }
        // GET: api/roles/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetRole(int id)
        {
            var question = await questionsService.GetRoleByIdAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }
        [HttpPost]
        public async Task<ActionResult<Question>> CreateRole(Question question)
        {
            await questionsService.CreateRoleAsync(question);
            return CreatedAtAction(nameof(GetRole), new { id = question.IdQues }, question);
        }
        // PUT: api/roles/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, Question question)
        {
            if (id != question.IdQues)
            {
                return BadRequest();
            }

            await questionsService.UpdateRoleAsync(question);
            return NoContent();
        }
        // DELETE: api/roles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await questionsService.DeleteRoleAsync(id);
            return NoContent();
        }
    }
}
