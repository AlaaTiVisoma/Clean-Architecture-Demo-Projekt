using Microsoft.AspNetCore.Mvc;
using BookStore.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Application.Interfaces;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksMongoController : ControllerBase
    {
        private readonly IBookServiceMongo _bookService;

        public BooksMongoController(IBookServiceMongo bookService)
        {
            _bookService = bookService;
        }

        // GET: api/BooksMongo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookMongo>>> GetBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        // GET: api/BooksMongo/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BookMongo>> GetBook(string id)
        {
            try
            {
                var book = await _bookService.GetBookByIdAsync(id);
                return Ok(book);
            }
            catch (ArgumentException)
            {
                return BadRequest("Invalid ID format.");
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: api/BooksMongo
        [HttpPost]
        public async Task<ActionResult<BookMongo>> PostBook(BookMongo book)
        {
            try
            {
                var createdBook = await _bookService.AddBookAsync(book);
                return CreatedAtAction(nameof(GetBook), new { id = createdBook.Id.ToString() }, createdBook);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Book cannot be null.");
            }
        }

        // PUT: api/BooksMongo/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(string id, BookMongo book)
        {
            try
            {
                await _bookService.UpdateBookAsync(id, book);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return BadRequest("Invalid ID format or Book ID mismatch.");
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/BooksMongo/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(string id)
        {
            try
            {
                await _bookService.DeleteBookAsync(id);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return BadRequest("Invalid ID format.");
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
