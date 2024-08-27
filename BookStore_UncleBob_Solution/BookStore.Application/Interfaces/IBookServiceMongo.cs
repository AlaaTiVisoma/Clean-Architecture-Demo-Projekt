using BookStore.Application.DTOs;
using BookStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Interfaces
{
    public interface IBookServiceMongo
    {
        Task<IEnumerable<BookMongo>> GetBooksByAuthorAsync(string author);
        Task<IEnumerable<BookMongoCustomerViewsDto>> GetAllBooksAsync();
        Task<BookMongo> GetBookByIdAsync(string id);
        Task<BookMongo> AddBookAsync(BookMongo book);
        Task UpdateBookAsync(string id, BookMongo book);
        Task DeleteBookAsync(string id);
    }
}
