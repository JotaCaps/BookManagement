using BookManagement.Application.Models;
using BookManagement.Application.Services;
using BookManagement.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;


namespace BookManagement.API.Controllers
{
    [ApiController]
    [Route("api/lendings")]
    public class LoanController : ControllerBase
    {
        private readonly BookManagementDbContext _context;
        public readonly ILoanService _service;

        public LoanController(BookManagementDbContext context, ILoanService service)
        {
            _context = context;
            _service = service;
        }

        [HttpPost]
        public IActionResult Post(RegisterLoanInputModel model)
        {
            var result = _service.Register(model);

            return Ok(result);
        }

        [HttpPatch("{id}/return")]
        public IActionResult RegisterReturn(int id, [FromBody] ReturnBookInputModel model)
        {
            var loan = _context.Loans.SingleOrDefault(l => l.Id == id);

            if (loan == null)
            {
                return NotFound("Empréstimo não encontrado");
            }

            if (loan.ReturnDate != null)
            {
                return BadRequest("O livro já foi devolvido");
            }

            loan.RegisterReturn(model.ReturnDate);
            _context.SaveChanges();

            var diasDeAtraso = (model.ReturnDate - loan.LoanDate).Days;

            if (diasDeAtraso > 1)
            {
                return Ok($"Livro devolvido com {diasDeAtraso - 1} dias de atraso");
            }
            else
            {
                return Ok("Devolução registrada no prazo");
            }
        }
    }
}
