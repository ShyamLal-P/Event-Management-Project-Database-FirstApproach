using Microsoft.AspNetCore.Mvc;
using EventManagementBackend.Models;
using EventManagementBackend.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManagementBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly FeedbackService _feedbackService;

        public FeedbackController(FeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetAllFeedbacks()
        {
            var feedbacks = await _feedbackService.GetAllFeedbacksAsync();
            return Ok(feedbacks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Feedback>> GetFeedbackById(int id)
        {
            var feedback = await _feedbackService.GetFeedbackByIdAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }
            return Ok(feedback);
        }

        [HttpPost]
        public async Task<ActionResult<Feedback>> CreateFeedback(Feedback newFeedback)
        {
            var createdFeedback = await _feedbackService.CreateFeedbackAsync(newFeedback);
            return CreatedAtAction(nameof(GetFeedbackById), new { id = createdFeedback.FeedbackID }, createdFeedback);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFeedback(int id, Feedback updatedFeedback)
        {
            if (id != updatedFeedback.FeedbackID)
            {
                return BadRequest();
            }

            await _feedbackService.UpdateFeedbackAsync(updatedFeedback);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            await _feedbackService.DeleteFeedbackAsync(id);
            return NoContent();
        }
    }
}