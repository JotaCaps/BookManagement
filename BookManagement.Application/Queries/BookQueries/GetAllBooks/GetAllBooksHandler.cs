using BookManagement.Application.Models;
using BookManagement.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.Queries.BookQueries.GetAllBooks
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, ResultViewModel<List<BookViewModel>>>
    {
        private readonly BookManagementDbContext _context;

        public GetAllBooksHandler(BookManagementDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<List<BookViewModel>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = _context.Books;

            var model = books.Select(BookViewModel.FromEntity).ToList();

            return ResultViewModel<List<BookViewModel>>.Success(model);
        }
    }
}
