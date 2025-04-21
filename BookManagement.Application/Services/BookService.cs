using BookManagement.Application.Models;
using BookManagement.Infrastructure.Persistence;


namespace BookManagement.Application.Services
{
    public class BookService : IBookService
    {
        private readonly BookManagementDbContext _context;

        public BookService(BookManagementDbContext context)
        {
            _context = context;
        }
        public ResultViewModel Delete(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            if (book == null)
            {
                return ResultViewModel.Error("O livro não existe");
            }

            _context.Books.Remove(book);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel<List<BookViewModel>> GetAll(string search = "")
        {
            var books = _context.Books;

            var model = books.Select(BookViewModel.FromEntity).ToList();

            return ResultViewModel<List<BookViewModel>>.Success(model);
        }

        public ResultViewModel<BookViewModel> GetById(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            if (book is null)
            {
                return ResultViewModel<BookViewModel>.Error("O livro não existe");
            }

            var model = BookViewModel.FromEntity(book);

            return ResultViewModel<BookViewModel>.Success(model);
        }

        public ResultViewModel<int> Register(RegisterBookInputModel model)
        {
            var book = model.ToEntity();

            _context.Books.Add(book);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(book.Id);
        }
    }
}
