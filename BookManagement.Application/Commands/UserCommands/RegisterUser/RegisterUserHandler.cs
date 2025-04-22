using BookManagement.Application.Models;
using BookManagement.Infrastructure.Persistence;
using MediatR;

namespace BookManagement.Application.Commands.UserCommands.RegisterUser
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, ResultViewModel<int>>
    {
        private readonly BookManagementDbContext _context;

        public RegisterUserHandler(BookManagementDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<int>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = request.ToEntity();

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return ResultViewModel<int>.Success(user.Id);
        }
    }
}
