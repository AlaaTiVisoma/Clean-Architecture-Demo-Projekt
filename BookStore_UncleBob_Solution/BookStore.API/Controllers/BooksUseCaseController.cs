using Microsoft.AspNetCore.Mvc;
using BookStore.Application.DTOs;
using BookStore.Application.UseCases;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class BooksUseCaseController : ControllerBase
{
    private readonly GetAllBooksUseCase _getAllBooksUseCase;
    private readonly GetBookByIdUseCase _getBookByIdUseCase;
    private readonly GetBookSummaryUseCase _getBookSummaryUseCase;
    private readonly AddBookUseCase _addBookUseCase;
    private readonly UpdateBookUseCase _updateBookUseCase;
    private readonly DeleteBookUseCase _deleteBookUseCase;

    public BooksUseCaseController(
        GetAllBooksUseCase getAllBooksUseCase,
        GetBookByIdUseCase getBookByIdUseCase,
        AddBookUseCase addBookUseCase,
        UpdateBookUseCase updateBookUseCase,
        DeleteBookUseCase deleteBookUseCase,
        GetBookSummaryUseCase getBookSummaryUseCase
        )
    {
        _getAllBooksUseCase = getAllBooksUseCase;
        _getBookByIdUseCase = getBookByIdUseCase;
        _addBookUseCase = addBookUseCase;
        _updateBookUseCase = updateBookUseCase;
        _deleteBookUseCase = deleteBookUseCase;
        _getBookSummaryUseCase = getBookSummaryUseCase;
    }
    [HttpGet("GetBookSummaryUseCase")]
    public async Task<ActionResult<IEnumerable<BookCustomerViewsMobileDto>>> GetBookSummaryUseCase()
    {
        var books = await _getBookSummaryUseCase.ExecuteAsync();
        return Ok(books);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookCustomerViewsDto>>> GetBooks()
    {
        var books = await _getAllBooksUseCase.ExecuteAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookCustomerViewsDto>> GetBookById(int id)
    {
        var book = await _getBookByIdUseCase.ExecuteAsync(id);
        if (book == null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    [HttpPost ("CreateBookAdminUseCase")]
    public async Task<ActionResult> AddBook([FromBody] BookAdminDto bookDto)
    {
        int newBookId  = await _addBookUseCase.ExecuteAsync(bookDto);
        return CreatedAtAction(nameof(GetBookById), new { id = newBookId }, new { Id = newBookId });
    }

    [HttpPut ("UpdateBookAdminUseCase")]
    public async Task<ActionResult> UpdateBook([FromBody] BookAdminDto bookDto)
    {
        await _updateBookUseCase.ExecuteAsync(bookDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBook(int id)
    {
        await _deleteBookUseCase.ExecuteAsync(id);
        return NoContent();
    }
}
