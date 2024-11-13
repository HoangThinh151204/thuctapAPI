using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using thuctapAPI.Model;
using thuctapAPI.Service;

namespace thuctapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService notificationService;
        public NotificationController(INotificationService accountService)
        {
            notificationService = accountService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notification>>> GetRoles()
        {
            var notifications = await notificationService.GetAllAccountAsync();
            return Ok(notifications);
        }
        // GET: api/roles/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Notification>> GetRole(int id)
        {
            var notification = await notificationService.GetRoleByIdAsync(id);
            if (notification == null)
            {
                return NotFound();
            }
            return Ok(notification);
        }
        [HttpPost]
        public async Task<ActionResult<JobImage>> CreateRole(Notification notification)
        {
            await notificationService.CreateRoleAsync(notification);
            return CreatedAtAction(nameof(GetRole), new { id = notification.IdNoti }, notification);
        }
        // PUT: api/roles/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, Notification notification)
        {
            if (id != notification.IdNoti)
            {
                return BadRequest();
            }

            await notificationService.UpdateRoleAsync(notification);
            return NoContent();
        }
        // DELETE: api/roles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await notificationService.DeleteRoleAsync(id);
            return NoContent();
        }
    }
}
