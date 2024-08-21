using AutoMapper;
using BookStore.Application.DTOs;
using BookStore.Core.Entities;
using BookStore.Core.Interfaces;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases
{
    public class GetBookByIdUseCase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBookByIdUseCase(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookCustomerViewsDto> ExecuteAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            return _mapper.Map<BookCustomerViewsDto>(book);
        }
    }
}