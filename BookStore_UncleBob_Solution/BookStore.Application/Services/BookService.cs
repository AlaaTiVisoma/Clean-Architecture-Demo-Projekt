using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Core.Entities;
using BookStore.Core.Interfaces;

namespace BookStore.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BookCustomerViewsMobileDto>> GetBookSummaryAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BookCustomerViewsMobileDto>>(books);
        }

        public async Task<IEnumerable<BookCustomerViewsDto>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BookCustomerViewsDto>>(books);
        }

        public async Task<BookCustomerViewsDto> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            return _mapper.Map<BookCustomerViewsDto>(book);
        }

        public async Task<int> AddBookAsync(BookAdminDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            Book newBook  = await _bookRepository.AddAsync(book);
            return newBook.Id;
        }

        public async Task UpdateBookAsync(BookAdminDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            await _bookRepository.UpdateAsync(book);
        }

        public async Task DeleteBookAsync(int id)
        {
            await _bookRepository.DeleteAsync(id);
        }

    }
}
