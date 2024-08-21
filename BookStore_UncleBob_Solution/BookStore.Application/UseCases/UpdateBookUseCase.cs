using AutoMapper;
using BookStore.Application.DTOs;
using BookStore.Core.Entities;
using BookStore.Core.Interfaces;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases
{
    public class UpdateBookUseCase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public UpdateBookUseCase(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(BookAdminDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            await _bookRepository.UpdateAsync(book);
        }
    }
}
