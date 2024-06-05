using Microsoft.AspNetCore.Mvc;
using BookLibraryApi.Models;
using BookLibraryApi.Data;

namespace BookLibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAPIController : ControllerBase
    {
        private readonly ILogger<BookAPIController> _logger;

        public BookAPIController(ILogger<BookAPIController> logger)
        {
            this._logger = logger;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return Ok(BookStore.BookList);
        }

        [HttpGet("{id:int}", Name = "GetBook")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = BookStore.BookList.FirstOrDefault(x => x.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]

        public ActionResult<Book> CreateBook([FromBody] Book book)
        {
            _logger.LogInformation("Creating a new book");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            book.Id = BookStore.BookList.OrderByDescending(b => b.Id).FirstOrDefault()?.Id + 1 ?? 1;

            BookStore.BookList.Add(book);
            return Ok(book);
        }

        [HttpPut("{id:int}")]

        public  IActionResult UpdateLibrary(int id, [FromBody] Book book)
        {
            if (id == 0 || id != book.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingbook = BookStore.BookList.FirstOrDefault(b => b.Id == book.Id);

            if (existingbook == null)
            {
                return NotFound();
            }

            existingbook.Id = book.Id;
            existingbook.Title = book.Title;
            existingbook.Author = book.Author;
            existingbook.ISBN = book.ISBN;
            existingbook.PublishedDate = book.PublishedDate;
            existingbook.Price = book.Price;

            return NoContent();
        }

        [HttpDelete("{id:int}")]

        public IActionResult DeleteBook(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var book = BookStore.BookList.FirstOrDefault(a => a.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            BookStore.BookList.Remove(book);

            return NoContent();
        }
    }
}
