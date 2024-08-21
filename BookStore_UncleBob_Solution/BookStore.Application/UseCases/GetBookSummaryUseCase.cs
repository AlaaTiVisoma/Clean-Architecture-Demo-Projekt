using BookStore.Application.DTOs;
using BookStore.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases
{
    public class GetBookSummaryUseCase
    {
        private readonly IBookRepository _bookRepository;
        public GetBookSummaryUseCase(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<IEnumerable<BookCustomerViewsMobileDto>> ExecuteAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return books.Select(book => new BookCustomerViewsMobileDto
            {
                //Id = book.Id,
                Title = book.Title,
                Author = book.Author,               
            });
        }

    }
}
