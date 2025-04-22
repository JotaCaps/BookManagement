using BookManagement.Application.Models;
using BookManagement.Infrastructure.Persistence;
using MediatR;

namespace BookManagement.Application.Commands.BookCommands.RegisterBook
{
    public class RegisterBookHandler : IRequestHandler<RegisterBookCommand, ResultViewModel<int>>
    {
        private readonly BookManagementDbContext _context;

        public RegisterBookHandler(BookManagementDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<int>> Handle(RegisterBookCommand request, CancellationToken cancellationToken)
        {
            var book = request.ToEntity();

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return ResultViewModel<int>.Success(book.Id);
        }
    }
}
