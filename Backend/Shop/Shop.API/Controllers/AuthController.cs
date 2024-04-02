using Microsoft.AspNetCore.Mvc;
using Shop.API.CQRS.Commands.Auth;
using Shop.API.CQRS.Handlers.Interfaces;
using Shop.Shared.Dtos.Response;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromServices] ICommandBaseHandler<UserLoginCommand, AuthDTO> handler, [FromBody] UserLoginCommand command)
        {
            throw new NotImplementedException();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromServices] ICommandBaseHandler<UserRegisterCommand, AuthDTO> handler, [FromBody] UserRegisterCommand command)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{id:guid}change-password")]
        public async Task<IActionResult> ChangePassword(Guid id, [FromServices] ICommandBaseHandler<UserRegisterCommand, AuthDTO> handler, [FromBody] UserPasswordChangedCommand command)
        {
            throw new NotImplementedException();
        }
    }
}