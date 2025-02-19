using EventManagementBackend.Models;
using EventManagementBackend.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManagementBackend.Services
{
    public class NotificationService
    {
        private readonly ApplicationDbContext _context;

        public NotificationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Notification>> GetAllNotificationsAsync()
        {
            return await _context.Notifications.ToListAsync();
        }

        public async Task<Notification> GetNotificationByIdAsync(int id)
        {
            return await _context.Notifications.FindAsync(id);
        }

        public async Task<Notification> CreateNotificationAsync(Notification newNotification)
        {
            _context.Notifications.Add(newNotification);
            await _context.SaveChangesAsync();
            return newNotification;
        }

        public async Task<Notification> UpdateNotificationAsync(Notification updatedNotification)
        {
            _context.Notifications.Update(updatedNotification);
            await _context.SaveChangesAsync();
            return updatedNotification;
        }

        public async Task DeleteNotificationAsync(int id)
        {
            var notificationToDelete = await _context.Notifications.FindAsync(id);
            if (notificationToDelete != null)
            {
                _context.Notifications.Remove(notificationToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }

}
