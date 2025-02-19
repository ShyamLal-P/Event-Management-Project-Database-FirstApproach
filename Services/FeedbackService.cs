using EventManagementBackend.Models;
using EventManagementBackend.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManagementBackend.Services
{
    public class FeedbackService
    {
        private readonly ApplicationDbContext _context;

        public FeedbackService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbacksAsync()
        {
            return await _context.Feedbacks.ToListAsync();
        }

        public async Task<Feedback> GetFeedbackByIdAsync(int id)
        {
            return await _context.Feedbacks.FindAsync(id);
        }

        public async Task<Feedback> CreateFeedbackAsync(Feedback newFeedback)
        {
            _context.Feedbacks.Add(newFeedback);
            await _context.SaveChangesAsync();
            return newFeedback;
        }

        public async Task<Feedback> UpdateFeedbackAsync(Feedback updatedFeedback)
        {
            _context.Feedbacks.Update(updatedFeedback);
            await _context.SaveChangesAsync();
            return updatedFeedback;
        }

        public async Task DeleteFeedbackAsync(int id)
        {
            var feedbackToDelete = await _context.Feedbacks.FindAsync(id);
            if (feedbackToDelete != null)
            {
                _context.Feedbacks.Remove(feedbackToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }

}
