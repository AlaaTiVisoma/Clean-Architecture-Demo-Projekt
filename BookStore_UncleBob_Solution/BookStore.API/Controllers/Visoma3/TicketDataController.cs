using BookStore.Application.DTOs.Visoma3;
using BookStore.Application.Interfaces.Visoma3;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers.Visoma3
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketDataController : ControllerBase
    {
        private readonly ITicketDataService _ticketDataService;

        public TicketDataController(ITicketDataService ticketDataService)
        {
            _ticketDataService = ticketDataService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketDataById(string id)
        {
            var ticketData = await _ticketDataService.GetTicketDataByIdAsync(id);
            if (ticketData == null) return NotFound();
            return Ok(ticketData);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTicketData()
        {
            var ticketDataList = await _ticketDataService.GetAllTicketDataAsync();
            return Ok(ticketDataList);
        }

        [HttpPost]
        public async Task<IActionResult> AddTicketData([FromBody] TicketDataDto ticketDataDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _ticketDataService.AddTicketDataAsync(ticketDataDto);
            return CreatedAtAction(nameof(GetTicketDataById), new { id = ticketDataDto.Id }, ticketDataDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicketData(string id, [FromBody] TicketDataDto ticketDataDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _ticketDataService.UpdateTicketDataAsync(id, ticketDataDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicketData(string id)
        {
            await _ticketDataService.DeleteTicketDataAsync(id);
            return NoContent();
        }
    }
}
