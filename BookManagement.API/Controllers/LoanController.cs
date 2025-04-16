using BookManagement.Application.Models;
using BookManagement.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;


namespace BookManagement.API.Controllers
{
    [ApiController]
    [Route("api/lendings")]
    public class LoanController : ControllerBase
    {
        private readonly BookManagementDbContext _context;

        public LoanController(BookManagementDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post(RegisterLoanInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lending = model.ToEntity();

            _context.Loans.Add(lending);
            _context.SaveChanges();

            return Ok();
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

            var diasDeAtraso = (model.ReturnDate - loan.LandingDate).Days;

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
