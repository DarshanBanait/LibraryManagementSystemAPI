using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystemAPI.Models;
using LibraryManagementSystemAPI.Services;

namespace LibraryManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly LibraryService _libraryService;

        public BooksController(LibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok(_libraryService.GetAllBooks());
        }

        [HttpGet("{title}")]
        public IActionResult GetBookByTitle(string title)
        {
            var books = _libraryService.GetBookByTitle(title).ToList();
            if (!books.Any())
            {
                return NotFound(new { Message = "No books found with the given title." });
            }
            return Ok(books);
        }


        [HttpGet("isbn/{isbn}")]
        public IActionResult GetBookByISBN(string isbn)
        {
            return Ok(_libraryService.GetBookByISBN(isbn));
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            if (!_libraryService.AddBook(book))
            {
                return Conflict(new { Message = "A book with the same ISBN already exists." });
            }
            return CreatedAtAction(nameof(GetBookByISBN), new { isbn = book.ISBN }, book);
        }

        [HttpPut("{isbn}")]
        public IActionResult UpdateBook(string isbn, [FromBody] Book book)
        {
            if (!_libraryService.UpdateBook(isbn, book))
            {
                return NotFound(new { Message = "Book not found." });
            }
            return NoContent();
        }


        [HttpDelete("{isbn}")]
        public IActionResult RemoveBook(string isbn)
        {
            if (!_libraryService.RemoveBook(isbn))
            {
                return NotFound(new { Message = "Book not found." });
            }
            return NoContent();
        }

    }
}