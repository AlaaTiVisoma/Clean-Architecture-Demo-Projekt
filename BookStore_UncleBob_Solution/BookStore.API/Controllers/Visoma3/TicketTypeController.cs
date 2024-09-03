using AutoMapper;
using BookStore.Application.DTOs.Visoma3;
using BookStore.Application.Interfaces.Visoma3;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookStore.API.Controllers.Visoma3
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketTypeController : ControllerBase
    {
        private readonly ITicketTypeService _ticketTypeService;
        public TicketTypeController(ITicketTypeService ticketTypeService)
        {
            _ticketTypeService = ticketTypeService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketTypeById(string id)
        {
            var ticketType = await _ticketTypeService.GetTicketTypeByIdAsync(id);
            if (ticketType == null) return NotFound();
            return Ok(ticketType);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTicketTypes()
        {
            IEnumerable<TicketTypeDto> ticketTypes = null;
            try
            {
                 ticketTypes = await _ticketTypeService.GetAllTicketTypesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return Ok(ticketTypes);
        }

        [HttpPost]
        public async Task<IActionResult> AddTicketType([FromBody] TicketTypeDto ticketTypeDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _ticketTypeService.AddTicketTypeAsync(ticketTypeDto);
            return CreatedAtAction(nameof(GetTicketTypeById), new { id = ticketTypeDto.Id }, ticketTypeDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicketType(string id, [FromBody] TicketTypeDto ticketTypeDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _ticketTypeService.UpdateTicketTypeAsync(id, ticketTypeDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicketType(string id)
        {
            await _ticketTypeService.DeleteTicketTypeAsync(id);
            return NoContent();
        }
    }
}
