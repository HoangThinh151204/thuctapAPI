using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using thuctapAPI.Model;
using thuctapAPI.Service;

namespace thuctapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyRequestsController : ControllerBase
    {
        private readonly ISurveyRequestsService surveyRequestsService;
        public SurveyRequestsController(ISurveyRequestsService accountService)
        {
            surveyRequestsService = accountService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SurveyRequest>>> GetRoles()
        {
            var surveyRequests = await surveyRequestsService.GetAllAccountAsync();
            return Ok(surveyRequests);
        }
        // GET: api/roles/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<SurveyRequest>> GetRole(int id)
        {
            var surveyRequests = await surveyRequestsService.GetRoleByIdAsync(id);
            if (surveyRequests == null)
            {
                return NotFound();
            }
            return Ok(surveyRequests);
        }
        [HttpPost]
        public async Task<ActionResult<SurveyRequest>> CreateRole(SurveyRequest surveyRequest)
        {
            await surveyRequestsService.CreateRoleAsync(surveyRequest);
            return CreatedAtAction(nameof(GetRole), new { id = surveyRequest.IdSR }, surveyRequest);
        }
        // PUT: api/roles/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, SurveyRequest surveyRequest)
        {
            if (id != surveyRequest.IdSR)
            {
                return BadRequest();
            }

            await surveyRequestsService.UpdateRoleAsync(surveyRequest);
            return NoContent();
        }
        // DELETE: api/roles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await surveyRequestsService.DeleteRoleAsync(id);
            return NoContent();
        }
    }
}
