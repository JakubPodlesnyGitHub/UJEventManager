using Microsoft.AspNetCore.Mvc;
using Shop.API.CQRS.Commands.User;
using Shop.API.CQRS.Handlers.Interfaces;
using Shop.API.CQRS.Queries.User;
using Shop.Shared.Dtos.Response;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetUser([FromServices] IQueryBaseHandler<GetUsersQuery, IList<UserDTO>> handler)
        {
            var result = await handler.HandleAsync(new GetUsersQuery());
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUserById(Guid id, [FromServices] IQueryBaseHandler<GetUserByIdQuery, UserDTO> handler)
        {
            var result = await handler.HandleAsync(new GetUserByIdQuery(id));
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddUser([FromServices] ICommandBaseHandler<AddedUserCommand, UserDTO> handler, [FromBody] AddedUserCommand command)
        {
            var result = await handler.HandleAsync(command);
            return Ok(result);
        }

        [HttpDelete("{id:guid}/delete")]
        public async Task<IActionResult> DeleteUser(Guid id, [FromServices] ICommandBaseHandler<DeletedUserCommand, UserDTO> handler)
        {
            var result = await handler.HandleAsync(new DeletedUserCommand(id));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromServices] ICommandBaseHandler<EditedUserCommand, UserDTO> handler, [FromBody] EditedUserCommand command)
        {
            var result = await handler.HandleAsync(command);
            return Ok(result);
        }
    }
}