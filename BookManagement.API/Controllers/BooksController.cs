using BookManagement.Application.Commands.BookCommands.DeleteBook;
using BookManagement.Application.Commands.BookCommands.RegisterBook;
using BookManagement.Application.Queries.BookQueries.GetAllBooks;
using BookManagement.Application.Queries.BookQueries.GetBookById;
using BookManagement.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.API.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _service;
        private readonly IMediator _mediator;

        public BooksController(IBookService service, IMediator mediator) 
        {
            _service = service;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(RegisterBookCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetBookByIdQuery(id)); 

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string search = "")
        {
            var result = _mediator.Send(new GetAllBooksQuery());

            return Ok(result);

        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {    
            var book = await _mediator.Send(new DeleteBookCommand(id));    

            if (book == null)
            {
               return BadRequest();
            }

            return NoContent();
        }
    }
}
