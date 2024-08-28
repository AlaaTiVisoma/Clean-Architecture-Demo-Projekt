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

        public async Task<bool> ExecuteAsync(int id , BookAdminDto bookDto)
        {
            // Fetch the existing book from the database
            var existingBook = await _bookRepository.GetByIdAsync(id);
            if (existingBook == null)
            {
                return false; // Book not found, return false
            }

            // Update the properties of the existing book with values from the DTO
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
    }
}
