using BookManagement.Application.Models;
using BookManagement.Application.Services;
using BookManagement.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.API.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _service;

        public BooksController(BookManagementDbContext context, IBookService service) 
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post(RegisterBookInputModel model)
        {
            var result = _service.Register(model);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll(string search = "")
        {
            var result = _service.GetAll();

            return Ok(result);

        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _service.Delete(id);    

            if (book == null)
            {
               return NoContent();
            }

            return NoContent();
        }
    }
}
