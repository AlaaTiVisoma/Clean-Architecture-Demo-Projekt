using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }
    [HttpGet("GetBookSummariesMobileAPP")]
    public async Task<ActionResult<IEnumerable<BookCustomerViewsMobileDto>>> GetBookSummariesAsync()
    {
        var books = await _bookService.GetBookSummaryAsync();
        return Ok(books);
    }

    [HttpGet("BooksByAuthorAsync")]
    public async Task<ActionResult<IEnumerable<BookMongoCustomerViewsDto>>> GetBooksByAuthorAsync(string author)
    {
        var books = await _bookService.GetBooksByAuthorAsync(author);
        return Ok(books);
    }


    [HttpGet("AllBooks")]
    public async Task<ActionResult<IEnumerable<BookCustomerViewsDto>>> GetBooks()
    {
        var books = await _bookService.GetAllBooksAsync();
        return Ok(books);
    }

    [HttpGet("ById/{id}")]
    public async Task<ActionResult<BookCustomerViewsDto>> GetBookById(int id)
    {
        var book = await _bookService.GetBookByIdAsync(id);
        if (book == null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    [HttpPost("CreateBookAdmin")]
    public async Task<ActionResult> CreateBook([FromBody] BookAdminDto bookDto)
    {
        if (bookDto == null)
        {
            return BadRequest();
        }
        int newBookId = await _bookService.AddBookAsync(bookDto);

        return CreatedAtAction(nameof(GetBookById), new { id = newBookId }, new { Id = newBookId });
    }

    [HttpPut("UpdateBookAdmin/{id}")]
    public async Task<ActionResult> UpdateBook(int id, [FromBody] BookAdminDto bookDto)
    {
        var existingBook = await _bookService.GetBookByIdAsync(id);
        if (existingBook == null)
        {
            return NotFound("Book not found.");
        }
        await _bookService.UpdateBookAsync(bookDto);
        return NoContent();
    }

    [HttpDelete("Delete/{id}")]
    public async Task<ActionResult> DeleteBook(int id)
    {
        await _bookService.DeleteBookAsync(id);
        return NoContent();
    }
}
