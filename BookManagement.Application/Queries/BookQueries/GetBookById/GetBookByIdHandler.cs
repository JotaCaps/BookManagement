using BookManagement.Application.Models;
using BookManagement.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Application.Queries.BookQueries.GetBookById
{
    internal class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, ResultViewModel<BookViewModel>>
    {
        private readonly BookManagementDbContext _context;

        public GetBookByIdHandler(BookManagementDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<BookViewModel>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.SingleOrDefaultAsync(b => b.Id == request.Id);

            if (book is null)
            {
                return ResultViewModel<BookViewModel>.Error("O livro não existe");
            }

            var model = BookViewModel.FromEntity(book);

            return ResultViewModel<BookViewModel>.Success(model);
        }
    }
}
