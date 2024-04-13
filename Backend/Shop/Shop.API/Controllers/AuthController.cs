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
        public async Task<IActionResult> Login([FromServices] IRequestHandler<UserLoginCommand, AuthDTO> handler, [FromBody] UserLoginCommand command)
        {
            throw new NotImplementedException();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromServices] IRequestHandler<UserRegisterCommand, AuthDTO> handler, [FromBody] UserRegisterCommand command)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{id:guid}change-password")]
        public async Task<IActionResult> ChangePassword(Guid id, [FromServices] IRequestHandler<UserRegisterCommand, AuthDTO> handler, [FromBody] UserPasswordChangedCommand command)
        {
            throw new NotImplementedException();
        }
    }
}