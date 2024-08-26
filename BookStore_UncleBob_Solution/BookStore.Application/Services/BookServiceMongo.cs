using BookStore.Application.Interfaces;
using BookStore.Core.Entities;
using BookStore.Core.Interfaces;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

public class BookServiceMongo : IBookServiceMongo
{
    private readonly IBookRepositoryMongo _bookRepository;

    public BookServiceMongo(IBookRepositoryMongo bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<IEnumerable<BookMongo>> GetAllBooksAsync()
    {
        return await _bookRepository.GetAllAsync();
    }

    public async Task<BookMongo> GetBookByIdAsync(string id)
    {
        if (!ObjectId.TryParse(id, out var objectId))
        {
            throw new ArgumentException("Invalid ID format.");
        }

        return await _bookRepository.GetByIdAsync(objectId);
    }

    public async Task<BookMongo> AddBookAsync(BookMongo book)
    {
        if (book == null)
        {
            throw new ArgumentNullException(nameof(book));
        }

        return await _bookRepository.AddAsync(book);
    }

    public async Task UpdateBookAsync(string id, BookMongo book)
    {
        if (!ObjectId.TryParse(id, out var objectId))
        {
            throw new ArgumentException("Invalid ID format.");
        }

        if (book == null)
        {
            throw new ArgumentException("Book ID mismatch.");
        }

        var existingBook = await _bookRepository.GetByIdAsync(objectId);
        if (existingBook == null)
        {
            throw new KeyNotFoundException("Book not found.");
        }

        await _bookRepository.UpdateAsync(book);
    }

    public async Task DeleteBookAsync(string id)
    {
        if (!ObjectId.TryParse(id, out var objectId))
        {
            throw new ArgumentException("Invalid ID format.");
        }

        var existingBook = await _bookRepository.GetByIdAsync(objectId);
        if (existingBook == null)
        {
            throw new KeyNotFoundException("Book not found.");
        }

        await _bookRepository.DeleteAsync(objectId);
    }
}
