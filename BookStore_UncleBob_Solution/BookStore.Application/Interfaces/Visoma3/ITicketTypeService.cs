using BookStore.Application.DTOs.Visoma3;
using BookStore.Core.Entities.Visoma3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Interfaces.Visoma3
{
    public interface ITicketTypeService
    {
        Task<TicketTypeDto> GetTicketTypeByIdAsync(string id);
        Task<IEnumerable<TicketTypeDto>> GetAllTicketTypesAsync();
        Task AddTicketTypeAsync(TicketTypeDto ticketTypeDto);
        Task UpdateTicketTypeAsync(string id, TicketTypeDto ticketTypeDto);
        Task DeleteTicketTypeAsync(string id);
    }
}
