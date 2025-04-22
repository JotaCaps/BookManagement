using BookManagement.Application.Models;
using BookManagement.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Application.Commands.LoanCommands.RegisterReturnCommand
{
    public class RegisterReturnHandler : IRequestHandler<RegisterReturnCommand, ResultViewModel<string>>
    {
        private readonly BookManagementDbContext _context;

        public RegisterReturnHandler(BookManagementDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<string>> Handle(RegisterReturnCommand request, CancellationToken cancellationToken)
        {
            var loan = await _context.Loans.SingleOrDefaultAsync(l => l.Id == request.Id);

            if (loan == null)
            {
                return ResultViewModel<string>.Error("Empréstimo não encontrado");
            }

            if (loan.ReturnDate != null)
            {
                return ResultViewModel<string>.Error("O livro já foi devolvido");
            }

            loan.RegisterReturn(request.ReturnDate);
            _context.SaveChanges();

            var diasDeAtraso = (request.ReturnDate - loan.LoanDate).Days;

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
