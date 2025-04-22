using BookManagement.Application.Models;
using BookManagement.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Application.Commands.BookCommands.DeleteBook
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, ResultViewModel>
    {
        private readonly BookManagementDbContext _context;

        public DeleteBookHandler(BookManagementDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.SingleOrDefaultAsync(b => b.Id == request.Id);

            if (book == null)
            {
                return ResultViewModel.Error("O livro não existe");
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
