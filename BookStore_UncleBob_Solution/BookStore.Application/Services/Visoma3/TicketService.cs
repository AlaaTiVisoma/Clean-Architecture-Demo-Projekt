using AutoMapper;
using BookStore.Application.DTOs.Visoma3;
using BookStore.Application.Interfaces.Visoma3;
using BookStore.Core.Entities.Visoma3;
using BookStore.Core.Interfaces.Visoma3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Services.Visoma3
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public TicketService(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        public async Task<TicketDto> GetTicketByIdAsync(string id)
        {
            var ticket = await _ticketRepository.GetByIdAsync(id);
            return _mapper.Map<TicketDto>(ticket);
        }

        public async Task<IEnumerable<TicketDto>> GetAllTicketsAsync()
        {
            var tickets = await _ticketRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TicketDto>>(tickets);
        }

        public async Task AddTicketAsync(TicketDto ticketDto)
        {
            var ticket = _mapper.Map<Ticket>(ticketDto);
            await _ticketRepository.AddAsync(ticket);
        }

        public async Task UpdateTicketAsync(string id, TicketDto ticketDto)
        {
            var ticket = _mapper.Map<Ticket>(ticketDto);
            await _ticketRepository.UpdateAsync(id, ticket);
        }

        public async Task DeleteTicketAsync(string id)
        {
            await _ticketRepository.DeleteAsync(id);
        }
    }
}
