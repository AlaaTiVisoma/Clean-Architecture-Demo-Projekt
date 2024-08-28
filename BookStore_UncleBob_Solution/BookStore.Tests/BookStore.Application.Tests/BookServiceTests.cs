using Xunit;
using Moq;
using FluentAssertions;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Application.Services;
using BookStore.Application.DTOs;
using BookStore.Core.Entities;
using BookStore.Core.Interfaces;
using BookStore.Infrastructure.Data;

public class BookServiceTests
{
    private readonly Mock<IBookRepository> _mockBookRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly BookService _bookService;

    public BookServiceTests()
    {
        _mockBookRepository = new Mock<IBookRepository>();
        _mockMapper = new Mock<IMapper>();
        _bookService = new BookService(_mockBookRepository.Object, _mockMapper.Object);
    }
    [Fact]
    public async Task GetAllBooksAsync_ShouldReturnAllBooks()
    {
        // Arrange
        var books = new List<Book>
            {
                new Book { Id = 1, Title = "Book 1", Author = "Author 1" },
                new Book { Id = 2, Title = "Book 2", Author = "Author 2" }
            };

        _mockBookRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(books);
        _mockMapper.Setup(m => m.Map<IEnumerable<BookCustomerViewsDto>>(books)).Returns(new List<BookCustomerViewsDto>
            {
                new BookCustomerViewsDto { Title = "Book 1" },
                new BookCustomerViewsDto { Title = "Book 2" }
            });

        // Act
        var result = await _bookService.GetAllBooksAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task AddBookAsync_ShouldAddBookSuccessfully()
    {
        // Arrange
        var bookDto = new BookAdminDto { Title = "New Book", Author = "Author 3" };
        var book = new Book { Id = 3, Title = "New Book", Author = "Author 3" };

        _mockMapper.Setup(m => m.Map<Book>(bookDto)).Returns(book);
        _mockBookRepository.Setup(repo => repo.AddAsync(book)).ReturnsAsync(book);

        // Act
        var result = await _bookService.AddBookAsync(bookDto);

        // Assert
        Assert.Equal(3, result);
        _mockBookRepository.Verify(repo => repo.AddAsync(book), Times.Once);
    }

    [Fact]
    public async Task UpdateBookAsync_ShouldUpdateBookSuccessfully()
    {
        // Arrange
        var bookDto = new BookAdminDto { Title = "New Book", Author = "Author 3" };
        var book = new Book { Id = 3, Title = "New Book", Author = "Author 3" };

    }
}
