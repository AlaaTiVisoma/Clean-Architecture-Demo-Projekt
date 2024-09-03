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
    public class TicketTypeService : ITicketTypeService
    {
        private readonly ITicketTypeRepository _ticketTypeRepository;
        private readonly IMapper _mapper;

        public TicketTypeService(ITicketTypeRepository ticketTypeRepository, IMapper mapper)
        {
            _ticketTypeRepository = ticketTypeRepository;
            _mapper = mapper;
        }

        public async Task<TicketTypeDto> GetTicketTypeByIdAsync(string id)
        {
            var ticketType = await _ticketTypeRepository.GetByIdAsync(id);
            return _mapper.Map<TicketTypeDto>(ticketType);
        }

        public async Task<IEnumerable<TicketTypeDto>> GetAllTicketTypesAsync()
        {
            IEnumerable<TicketTypeDto> tmp = null;
            var ticketTypes = await _ticketTypeRepository.GetAllAsync();
            try
            {
                tmp = _mapper.Map<IEnumerable<TicketTypeDto>>(ticketTypes);
            }
            catch (Exception ex)
            {

                throw;
            }
            return tmp;
        }

        public async Task AddTicketTypeAsync(TicketTypeDto ticketTypeDto)
        {
            var ticketType = _mapper.Map<TicketType>(ticketTypeDto);
            await _ticketTypeRepository.AddAsync(ticketType);
        }

        public async Task UpdateTicketTypeAsync(string id, TicketTypeDto ticketTypeDto)
        {
            var ticketType = _mapper.Map<TicketType>(ticketTypeDto);
            await _ticketTypeRepository.UpdateAsync(id, ticketType);
        }

        public async Task DeleteTicketTypeAsync(string id)
        {
            await _ticketTypeRepository.DeleteAsync(id);
        }
    }
}
