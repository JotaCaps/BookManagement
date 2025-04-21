using BookManagement.Application.Models;
using BookManagement.Infrastructure.Persistence;

namespace BookManagement.Application.Services
{
    public class LoanService : ILoanService
    {
        private readonly BookManagementDbContext _context;

        public LoanService(BookManagementDbContext context)
        {
            _context = context;
        }
        public ResultViewModel<int> Register(RegisterLoanInputModel model)
        {

            var loan = model.ToEntity();

            _context.Loans.Add(loan);
            _context.SaveChanges();
            return ResultViewModel<int>.Success(loan.Id);
        }

        public ResultViewModel<string> Return(int id, ReturnBookInputModel model)
        {
            var loan = _context.Loans.SingleOrDefault(l => l.Id == id);

            if (loan == null)
            {
                return ResultViewModel<string>.Error("Empréstimo não encontrado");
            }

            if (loan.ReturnDate != null)
            {
                return ResultViewModel<string>.Error("O livro já foi devolvido");
            }

            loan.RegisterReturn(model.ReturnDate);
            _context.SaveChanges();

            var diasDeAtraso = (model.ReturnDate - loan.LoanDate).Days;

            if (diasDeAtraso > 1)
            {
                return ResultViewModel<string>.Error($"Livro devolvido com {diasDeAtraso - 1} dias de atraso");
            }
            else
            {
                return ResultViewModel<string>.Error("Devolução registrada no prazo");
            }
        }
    }
}
