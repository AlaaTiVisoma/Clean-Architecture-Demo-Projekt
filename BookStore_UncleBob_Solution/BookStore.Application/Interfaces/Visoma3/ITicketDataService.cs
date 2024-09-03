using BookStore.Application.DTOs.Visoma3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Interfaces.Visoma3
{
   
    public interface ITicketDataService
    {
        Task<TicketDataDto> GetTicketDataByIdAsync(string id);
        Task<IEnumerable<TicketDataDto>> GetAllTicketDataAsync();
        Task AddTicketDataAsync(TicketDataDto ticketDataDto);
        Task UpdateTicketDataAsync(string id, TicketDataDto ticketDataDto);
        Task DeleteTicketDataAsync(string id);
    }
}
