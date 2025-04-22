using BookManagement.Application.Commands.LoanCommands.RegisterLoanCommand;
using BookManagement.Application.Commands.LoanCommands.RegisterReturnCommand;
using BookManagement.Application.Models;
using BookManagement.Application.Services;
using BookManagement.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace BookManagement.API.Controllers
{
    [ApiController]
    [Route("api/lendings")]
    public class LoanController : ControllerBase
    {
        public readonly ILoanService _service;
        public readonly IMediator _mediator;

        public LoanController(ILoanService service, IMediator mediator)
        {
            _service = service;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(RegisterLoanCommand model)
        {
            var result = await _mediator.Send(model);

            return Ok(result);
        }

        [HttpPatch("{id}/return")]
        public async Task<IActionResult> RegisterReturn(int id, [FromBody] RegisterReturnCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);          
        }
    }
}
