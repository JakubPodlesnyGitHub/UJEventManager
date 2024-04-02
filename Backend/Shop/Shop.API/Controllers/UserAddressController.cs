using Microsoft.AspNetCore.Mvc;
using Shop.API.CQRS.Commands.UserAddress;
using Shop.API.CQRS.Handlers.Interfaces;
using Shop.API.CQRS.Queries.UserAddress;
using Shop.Shared.Dtos.Response;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAddressController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetUserAddresses([FromServices] IQueryBaseHandler<GetUserAddressesQuery, IList<UserAddressDTO>> handler)
        {
            var result = await handler.HandleAsync(new GetUserAddressesQuery());
            return Ok(result);
        }

        [HttpGet("/{id:guid}")]
        public async Task<IActionResult> GetUserAddressById(Guid id, [FromServices] IQueryBaseHandler<GetUserAddressByIdQuery, UserAddressDTO> handler)
        {
            var result = await handler.HandleAsync(new GetUserAddressByIdQuery(id));
            return Ok(result);
        }

        [HttpPost("/create")]
        public async Task<IActionResult> AddUserAddress([FromServices] ICommandBaseHandler<AddedUserAddressCommand, UserAddressDTO> handler, [FromBody] AddedUserAddressCommand command)
        {
            var result = await handler.HandleAsync(command);
            return Ok(result);
        }

        [HttpDelete("/{id:guid}/delete")]
        public async Task<IActionResult> DeleteUserAddress(Guid id, [FromServices] ICommandBaseHandler<DeletedUserAdressCommand, UserAddressDTO> handler)
        {
            var result = await handler.HandleAsync(new DeletedUserAdressCommand(id));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserAddress([FromServices] ICommandBaseHandler<EdditedUserAdressCommand, UserAddressDTO> handler, [FromBody] EdditedUserAdressCommand command)
        {
            var result = await handler.HandleAsync(command);
            return Ok(result);
        }
    }
}