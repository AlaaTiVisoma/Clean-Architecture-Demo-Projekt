using Xunit;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookStore.Infrastructure.Data.Repositories;
using BookStore.Core.Entities;
using BookStore.Infrastructure.Data;


namespace BookStore.Tests.BookStore.Infrastructure.Tests
{
    public class BookRepositoryTests
    {
        private readonly BookStoreDbContext _context;
        private readonly BookRepository _bookRepository;
        public BookRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<BookStoreDbContext>()
                .UseInMemoryDatabase(databaseName: "BookStoreTestDatabase")
                .Options;

            _context = new BookStoreDbContext(options);
            _bookRepository = new BookRepository(_context);
            // Seed initial data
            _context.Books.AddRange(new List<Book>
        {
            new Book { Id = 1, Title = "Book 1", Author = "Author A" },
            new Book { Id = 2, Title = "Book 2", Author = "Author B" },
            new Book { Id = 3, Title = "Book 3", Author = "Author A" }
        });
            _context.SaveChanges();
        }

        [Fact]
        public async Task GetBooksByAuthorAsync_ShouldReturnBooksByAuthor()
        {
            // Arrange
            var author = "Author A";

            // Act
            var result = await _bookRepository.GetBooksByAuthorAsync(author);

            // Assert
            Assert.Equal(2, result.Count()); // Expecting 2 books for "Author A"
        }

        [Fact]
        public async Task GetBooksByAuthorAsync_ShouldReturnEmpty_WhenNoBooksFound()
        {
            // Arrange
            var author = "Nonexistent Author";

            // Act
            var result = await _bookRepository.GetBooksByAuthorAsync(author);

            // Assert
            Assert.Empty(result); // Expecting no books for "Nonexistent Author"
        }
    }
}
