using Microsoft.AspNetCore.Mvc;
using EventManagementBackend.Models;
using EventManagementBackend.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManagementBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly TicketService _ticketService;

        public TicketController(TicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetAllTickets()
        {
            var tickets = await _ticketService.GetAllTicketsAsync();
            return Ok(tickets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicketById(int id)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }

        [HttpPost]
        public async Task<ActionResult<Ticket>> CreateTicket(Ticket newTicket)
        {
            var createdTicket = await _ticketService.CreateTicketAsync(newTicket);
            return CreatedAtAction(nameof(GetTicketById), new { id = createdTicket.TicketID }, createdTicket);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(int id, Ticket updatedTicket)
        {
            if (id != updatedTicket.TicketID)
            {
                return BadRequest();
            }

            await _ticketService.UpdateTicketAsync(updatedTicket);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            await _ticketService.DeleteTicketAsync(id);
            return NoContent();
        }
    }
}
