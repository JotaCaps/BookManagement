using BookManagement.Application.Models;
using BookManagement.Application.Services;
using BookManagement.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly BookManagementDbContext _context;
        private readonly IUserService _service;

        public UsersController(BookManagementDbContext context, IUserService service)
        {
            _context = context;
            _service = service;
        }

        [HttpPost]
        public IActionResult Post(RegisterUserInputModel model)
        {
            var result = _service.Register(model);

            return Ok(result);
        }
    }
}
