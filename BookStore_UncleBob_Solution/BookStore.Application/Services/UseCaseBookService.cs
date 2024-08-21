using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Services
{
    public class UseCaseBookService : IBookService
    {
        private readonly GetAllBooksUseCase _getAllBooksUseCase;
        private readonly GetBookSummaryUseCase _getBookSummaryUseCase;
        private readonly GetBookByIdUseCase _getBookByIdUseCase;
        private readonly AddBookUseCase _addBookUseCase;
        private readonly UpdateBookUseCase _updateBookUseCase;
        private readonly DeleteBookUseCase _deleteBookUseCase;

        public UseCaseBookService(
            GetAllBooksUseCase getAllBooksUseCase,
            GetBookByIdUseCase getBookByIdUseCase,
            AddBookUseCase addBookUseCase,
            UpdateBookUseCase updateBookUseCase,
            DeleteBookUseCase deleteBookUseCase,
            GetBookSummaryUseCase getBookSummaryUseCase)
        {
            _getAllBooksUseCase = getAllBooksUseCase;
            _getBookByIdUseCase = getBookByIdUseCase;
            _addBookUseCase = addBookUseCase;
            _updateBookUseCase = updateBookUseCase;
            _deleteBookUseCase = deleteBookUseCase;
            _getBookSummaryUseCase = getBookSummaryUseCase;
        }
        
        public async Task<IEnumerable<BookCustomerViewsMobileDto>> GetBookSummaryAsync()
        {
            return await _getBookSummaryUseCase.ExecuteAsync();
        }
        public async Task<IEnumerable<BookCustomerViewsDto>> GetAllBooksAsync()
        {
            return await _getAllBooksUseCase.ExecuteAsync();
        }

        public async Task<BookCustomerViewsDto> GetBookByIdAsync(int id)
        {
            return await _getBookByIdUseCase.ExecuteAsync(id);
        }

        public async Task<int> AddBookAsync(BookAdminDto bookDto)
        {
            int newBookId = await _addBookUseCase.ExecuteAsync(bookDto);
            return newBookId;
        }

        public async Task UpdateBookAsync(BookAdminDto bookDto)
        {
            await _updateBookUseCase.ExecuteAsync(bookDto);
        }

        public async Task DeleteBookAsync(int id)
        {
            await _deleteBookUseCase.ExecuteAsync(id);
        }
    }
}
