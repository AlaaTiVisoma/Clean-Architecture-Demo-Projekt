using AutoMapper;
using BookStore.Application.DTOs;
using BookStore.Core.Entities;
using BookStore.Core.Interfaces;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases
{
    public class AddBookUseCase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public AddBookUseCase(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<int> ExecuteAsync(BookAdminDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            Book newBook  =  await _bookRepository.AddAsync(book);
            return newBook.Id;
        }
    }
}
