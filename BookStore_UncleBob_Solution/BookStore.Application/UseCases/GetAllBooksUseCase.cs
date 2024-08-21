using BookStore.Application.DTOs;
using BookStore.Core.Entities;
using BookStore.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases
{
    public class GetAllBooksUseCase
    {
        private readonly IBookRepository _bookRepository;

        public GetAllBooksUseCase(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookCustomerViewsDto>> ExecuteAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return books.Select(book => new BookCustomerViewsDto
            {
                //Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                FinalPrice = book.Price,
                PublishedDate = book.PublishedDate,
            });
        }
    }
}
