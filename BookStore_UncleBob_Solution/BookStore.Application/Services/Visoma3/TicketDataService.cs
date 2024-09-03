using AutoMapper;
using BookStore.Application.DTOs.Visoma3;
using BookStore.Application.Interfaces.Visoma3;
using BookStore.Core.Entities.Visoma3;
using BookStore.Core.Interfaces.Visoma3;
using BookStore.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Services.Visoma3
{
    public class TicketDataService : ITicketDataService
    {
        private readonly ITicketDataRepository _ticketDataRepository;
        private readonly IMapper _mapper;
        private readonly VisomaTicketDbContext _visomaTicketDbContext;


        public TicketDataService(ITicketDataRepository ticketDataRepository, IMapper mapper , VisomaTicketDbContext visomaTicketDbContext)
        {
            _ticketDataRepository = ticketDataRepository;
            _mapper = mapper;
            _visomaTicketDbContext = visomaTicketDbContext;
        }

        public async Task<TicketDataDto> GetTicketDataByIdAsync(string id)
        {
            var ticketData = await _ticketDataRepository.GetByIdAsync(id);
            return _mapper.Map<TicketDataDto>(ticketData);
        }

        public async Task<IEnumerable<TicketDataDto>> GetAllTicketDataAsync()
        {
            var ticketDataList = await _ticketDataRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TicketDataDto>>(ticketDataList);
        }

        public async Task AddTicketDataAsync(TicketDataDto ticketDataDto)
        {
            var ticketData = _mapper.Map<TicketData>(ticketDataDto);
            await _ticketDataRepository.AddAsync(ticketData);
        }

        public async Task UpdateTicketDataAsync(string id, TicketDataDto ticketDataDto)
        {
            var ticketData = _mapper.Map<TicketData>(ticketDataDto);
            await _ticketDataRepository.UpdateAsync(id, ticketData);
        }

        public async Task DeleteTicketDataAsync(string id)
        {
            await _ticketDataRepository.DeleteAsync(id);
        }
    }
}
