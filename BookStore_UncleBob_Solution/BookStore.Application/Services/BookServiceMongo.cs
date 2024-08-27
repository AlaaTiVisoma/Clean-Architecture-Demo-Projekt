using AutoMapper;
using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Core.Entities;
using BookStore.Core.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using BookStore.Infrastructure.Data;

public class BookServiceMongo : IBookServiceMongo
{
    private readonly IBookRepositoryMongo _bookRepository;
    private readonly IMapper _mapper;
    private readonly MongoDbContext _mongoDbContext;
    public BookServiceMongo(IBookRepositoryMongo bookRepository, IMapper mapper , MongoDbContext mongoDbContext)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
        _mongoDbContext = mongoDbContext;
    }
    public async Task<IEnumerable<BookMongo>> GetBooksByAuthorAsync(string author)
    {
        var filter = Builders<BookMongo>.Filter.Eq(b => b.Author, author);
        return await _mongoDbContext.Books.Find(filter).ToListAsync();
    }
    public async Task<IEnumerable<BookMongoCustomerViewsDto>> GetAllBooksAsync()
    {
        //return await _bookRepository.GetAllAsync();
        var books = await _bookRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<BookMongoCustomerViewsDto>>(books);
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
