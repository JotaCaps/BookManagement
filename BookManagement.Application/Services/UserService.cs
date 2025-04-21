using BookManagement.Application.Models;
using BookManagement.Infrastructure.Persistence;

namespace BookManagement.Application.Services
{
    public class UserService : IUserService
    {
        private readonly BookManagementDbContext _context;

        public UserService(BookManagementDbContext context)
        {
            _context = context;
        }

        public ResultViewModel<int> Register(RegisterUserInputModel model)
        {
            var user = model.ToEntity();

            _context.Users.Add(user);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(user.Id);
        }
    }
}
