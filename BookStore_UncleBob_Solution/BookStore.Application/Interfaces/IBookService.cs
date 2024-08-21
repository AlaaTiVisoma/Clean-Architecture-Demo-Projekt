using BookStore.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookCustomerViewsMobileDto>> GetBookSummaryAsync();
        Task<IEnumerable<BookCustomerViewsDto>> GetAllBooksAsync();
        Task<BookCustomerViewsDto> GetBookByIdAsync(int id);
        Task<int> AddBookAsync(BookAdminDto bookDto);
        Task UpdateBookAsync(BookAdminDto bookDto);
        Task DeleteBookAsync(int id);
    }
}
