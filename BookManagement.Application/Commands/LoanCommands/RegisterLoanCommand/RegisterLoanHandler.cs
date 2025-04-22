using BookManagement.Application.Models;
using BookManagement.Infrastructure.Persistence;
using MediatR;

namespace BookManagement.Application.Commands.LoanCommands.RegisterLoanCommand
{
    public class RegisterLoanHandler : IRequestHandler<RegisterLoanCommand, ResultViewModel<int>>
    {
        private readonly BookManagementDbContext _context;

        public RegisterLoanHandler(BookManagementDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<int>> Handle(RegisterLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = request.ToEntity();

            await _context.Loans.AddAsync(loan);
            await _context.SaveChangesAsync();
            return ResultViewModel<int>.Success(loan.Id);
        }
    }
}
