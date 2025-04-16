using BookManagement.Application.Models;
using BookManagement.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly BookManagementDbContext _context;

        public UsersController(BookManagementDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post(RegisterUserInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = model.ToEntity();

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(user);
        }
    }
}
