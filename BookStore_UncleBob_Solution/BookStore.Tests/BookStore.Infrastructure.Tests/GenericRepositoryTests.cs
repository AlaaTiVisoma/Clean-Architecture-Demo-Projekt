using BookStore.Core.Entities;
using BookStore.Infrastructure.Data.Repositories;
using BookStore.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Tests.BookStore.Infrastructure.Tests
{
    public class GenericRepositoryTests
    {
        private readonly BookStoreDbContext _context;
        private readonly GenericRepository<Book> _genericRepository;


        public GenericRepositoryTests()
        {
            // Setting up the in-memory DbContext
            var options = new DbContextOptionsBuilder<BookStoreDbContext>()
                .UseInMemoryDatabase(databaseName: "BookStoreTestDb")
                .Options;

            _context = new BookStoreDbContext(options);
            _genericRepository = new GenericRepository<Book>(_context);

            // Seeding data into the in-memory database
            _context.Books.AddRange(new List<Book>
        {
            new Book { Id = 1, Title = "Book 1", Author = "Author A", Price = 10.99m , CategoryId = 1  },
            new Book { Id = 2, Title = "Book 2", Author = "Author B", Price = 12.99m , CategoryId = 1 },
            new Book { Id = 3, Title = "Book 3", Author = "Author A", Price = 8.99m  , CategoryId = 1}
        });
            _context.SaveChanges();
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnEntity_WhenEntityExists()
        {
            // Act
            var result = await _genericRepository.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result); // Ensure the result is not null
            Assert.Equal(1, result.Id); // Check that the ID matches
            Assert.Equal("Book 1", result.Title); // Check that the title matches
            Assert.Equal("Author A", result.Author); // Check that the author matches
        }

        [Fact]
        public async Task AddAsync_ShouldAddEntitySuccessfully()
        {
            // Arrange
            var newBook = new Book { Title = "New Book", Author = "New Author" };

            // Act
            var addedBook = await _genericRepository.AddAsync(newBook);
            var result = await _context.Books.FindAsync(addedBook.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(newBook.Title, result.Title);
            Assert.Equal(newBook.Author, result.Author);
        }


    }
}
