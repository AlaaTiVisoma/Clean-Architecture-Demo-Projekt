using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Core.Entities;
using BookStore.Core.Interfaces;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookStore.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(string author)
        {
            var books = await _bookRepository.GetBooksByAuthorAsync(author);
            return books;
        }
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

            /*
            // Simulate wrong data by filtering out all books
             var books = await _bookRepository.GetAllAsync();
             var filteredBooks = books.Where(b => b.Title != "Book 1");
             return _mapper.Map<IEnumerable<BookCustomerViewsDto>>(filteredBooks);
             */
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

        public async Task<bool> UpdateBookAsync(int id , BookAdminDto bookDto)
        {
            try
            {
                // Fetch the existing book from the database
                var existingBook = await _bookRepository.GetByIdAsync(id);
                if (existingBook == null)
                {
                    return false; // Book not found, return false
                }

                existingBook.Title = bookDto.Title;
                existingBook.Author = bookDto.Author;
                existingBook.Price = bookDto.Price;
                existingBook.Stock = bookDto.Stock;
                existingBook.NumberOfPages = bookDto.NumberOfPages;
                existingBook.IsDiscounted = bookDto.IsDiscounted;
                existingBook.DiscountedPrice = bookDto.DiscountedPrice;
                existingBook.PublishedDate = bookDto.PublishedDate;

                // Save changes
                await _bookRepository.UpdateAsync(existingBook);
                return true; // Indicate that the update was successful
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task DeleteBookAsync(int id)
        {
            await _bookRepository.DeleteAsync(id);
        }

      
    }
}
