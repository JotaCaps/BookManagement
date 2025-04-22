using BookManagement.Application.Commands.UserCommands.RegisterUser;
using BookManagement.Application.Models;
using BookManagement.Application.Services;
using BookManagement.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMediator _mediator;

        public UsersController(IUserService service, IMediator mediator)
        {
            _service = service;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(RegisterUserCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
