using BookManagement.Application.Models;

namespace BookManagement.Application.Services
{
    public interface ILoanService
    {
        ResultViewModel<int> Register(RegisterLoanInputModel model);
    }
}
