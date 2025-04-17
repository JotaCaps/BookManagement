using BookManagement.Application.Models;

namespace BookManagement.Application.Services
{
    public interface IBookService
    {
        ResultViewModel<int> Register(RegisterBookInputModel model);
        ResultViewModel<List<BookViewModel>> GetAll(string search ="");
        ResultViewModel<BookViewModel> GetById(int id);
        ResultViewModel Delete(int id);
    }
}
