using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using thuctapAPI.Model;
using thuctapAPI.Service;

namespace thuctapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyArticleController : ControllerBase
    {
        private readonly ISurveyArticleService surveyArticleService;
        public SurveyArticleController(ISurveyArticleService accountService)
        {
            surveyArticleService = accountService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            var surveyArticles = await surveyArticleService.GetAllAccountAsync();
            return Ok(surveyArticles);
        }
        // GET: api/roles/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<SurveyArticle>> GetRole(int id)
        {
            var surveyArticle = await surveyArticleService.GetRoleByIdAsync(id);
            if (surveyArticle == null)
            {
                return NotFound();
            }
            return Ok(surveyArticle);
        }
        [HttpPost]
        public async Task<ActionResult<SurveyArticle>> CreateRole(SurveyArticle surveyArticle)
        {
            await surveyArticleService.CreateRoleAsync(surveyArticle);
            return CreatedAtAction(nameof(GetRole), new { id = surveyArticle.IdSA }, surveyArticle);
        }
        // PUT: api/roles/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, SurveyArticle surveyArticle)
        {
            if (id != surveyArticle.IdSA)
            {
                return BadRequest();
            }

            await surveyArticleService.UpdateRoleAsync(surveyArticle);
            return NoContent();
        }
        // DELETE: api/roles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await surveyArticleService.DeleteRoleAsync(id);
            return NoContent();
        }
    }
}
