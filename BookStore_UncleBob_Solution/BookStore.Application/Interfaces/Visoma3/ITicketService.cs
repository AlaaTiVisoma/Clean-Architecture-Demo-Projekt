using BookStore.Application.DTOs.Visoma3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Interfaces.Visoma3
{
    public interface ITicketService
    {
        Task<TicketDto> GetTicketByIdAsync(string id);
        Task<IEnumerable<TicketDto>> GetAllTicketsAsync();
        Task AddTicketAsync(TicketDto ticketDto);
        Task UpdateTicketAsync(string id, TicketDto ticketDto);
        Task DeleteTicketAsync(string id);
    }
}
