using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using thuctapAPI.Model;
using thuctapAPI.Service;

namespace thuctapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService articleService;
        public ArticleController(IArticleService accountService)
        {
            articleService = accountService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Article>>> GetRoles()
        {
            var articles = await articleService.GetAllAccountAsync();
            return Ok(articles);
        }
        // GET: api/roles/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetRole(int id)
        {
            var articles = await articleService.GetRoleByIdAsync(id);
            if (articles == null)
            {
                return NotFound();
            }
            return Ok(articles);
        }
        [HttpPost]
        public async Task<ActionResult<Article>> CreateRole(Article article)
        {
            await articleService.CreateRoleAsync(article);
            return CreatedAtAction(nameof(GetRole), new { id = article.IdArticle }, article);
        }
        // PUT: api/roles/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, Article article)
        {
            if (id != article.IdArticle)
            {
                return BadRequest();
            }

            await articleService.UpdateRoleAsync(article);
            return NoContent();
        }
        // DELETE: api/roles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await articleService.DeleteRoleAsync(id);
            return NoContent();
        }
    }
}
