using BookApi.Data.Repositories;
using BookApi.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _bookRepository.GetById(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpGet("byName/{name}")]
        public async Task<ActionResult<Book>> GetBookByName(string name)
        {
            var book = await _bookRepository.GetBookByName(name);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(Book book)
        {
            await _bookRepository.InsertBook(book);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatedBooks(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            try
            {
                await _bookRepository.UpdateBook(book);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _bookRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            await _bookRepository.DeleteBook(id);
            return NoContent();
        }


        private bool BookExist(int id)
        {
            return _bookRepository.GetAllBooks().Result.Any(e => e.Id == id);
        }
    }
}