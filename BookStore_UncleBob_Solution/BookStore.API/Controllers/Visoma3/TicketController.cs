using BookStore.Application.DTOs.Visoma3;
using BookStore.Application.Interfaces.Visoma3;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers.Visoma3
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketById(string id)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);
            if (ticket == null) return NotFound();
            return Ok(ticket);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTickets()
        {
            var tickets = await _ticketService.GetAllTicketsAsync();
            return Ok(tickets);
        }

        [HttpPost]
        public async Task<IActionResult> AddTicket([FromBody] TicketDto ticketDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _ticketService.AddTicketAsync(ticketDto);
            return CreatedAtAction(nameof(GetTicketById), new { id = ticketDto.Id }, ticketDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(string id, [FromBody] TicketDto ticketDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _ticketService.UpdateTicketAsync(id, ticketDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(string id)
        {
            await _ticketService.DeleteTicketAsync(id);
            return NoContent();
        }
    }
}
