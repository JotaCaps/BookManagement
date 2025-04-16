using BookManagement.Application.Models;
using BookManagement.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.API.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly BookManagementDbContext _context;

        public BooksController(BookManagementDbContext context) 
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post(RegisterBookInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = model.ToEntity();

            _context.Books.Add(book);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = book.Id }, model);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _context.Books;

            var model = book.Where(b => b.Id == id).FirstOrDefault();
            
            return Ok(model);
        }

        [HttpGet]
        public IActionResult GetAll(string search = "")
        {
            var books = _context.Books;

            var model = books.Select(BookViewModel.FromEntity).ToList();

            return Ok(model);

        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            if (book == null)
            {
               return NoContent();
            }

            _context.Books.Remove(book);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
