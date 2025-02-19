using Microsoft.AspNetCore.Mvc;
using EventManagementBackend.Models;
using EventManagementBackend.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManagementBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly NotificationService _notificationService;

        public NotificationController(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notification>>> GetAllNotifications()
        {
            var notifications = await _notificationService.GetAllNotificationsAsync();
            return Ok(notifications);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Notification>> GetNotificationById(int id)
        {
            var notification = await _notificationService.GetNotificationByIdAsync(id);
            if (notification == null)
            {
                return NotFound();
            }
            return Ok(notification);
        }

        [HttpPost]
        public async Task<ActionResult<Notification>> CreateNotification(Notification newNotification)
        {
            var createdNotification = await _notificationService.CreateNotificationAsync(newNotification);
            return CreatedAtAction(nameof(GetNotificationById), new { id = createdNotification.NotificationID }, createdNotification);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotification(int id, Notification updatedNotification)
        {
            if (id != updatedNotification.NotificationID)
            {
                return BadRequest();
            }

            await _notificationService.UpdateNotificationAsync(updatedNotification);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            await _notificationService.DeleteNotificationAsync(id);
            return NoContent();
        }
    }
}

