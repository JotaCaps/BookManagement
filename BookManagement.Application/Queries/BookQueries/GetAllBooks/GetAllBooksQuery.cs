using BookManagement.Application.Models;
using MediatR;

namespace BookManagement.Application.Queries.BookQueries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<ResultViewModel<List<BookViewModel>>>
    {

    }
}
