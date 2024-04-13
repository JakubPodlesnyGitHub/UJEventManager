using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.API.CQRS.Commands.Auth;
using Shop.Shared.Dtos.Response;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("{id:guid}change-password")]
        public async Task<IActionResult> ChangePassword(Guid id, [FromBody] UserPasswordChangedCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}