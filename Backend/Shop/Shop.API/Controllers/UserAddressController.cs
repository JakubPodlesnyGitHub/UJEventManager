using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.API.CQRS.Commands.UserAddress;
using Shop.API.CQRS.Queries.UserAddress;
using Shop.Shared.Dtos.Response;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserAddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserAddresses()
        {
            var result = await _mediator.Send(new GetUserAddressesQuery());
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUserAddressById(Guid id)
        {
            var result = await _mediator.Send(new GetUserAddressByIdQuery(id));
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddUserAddress([FromBody] AddedUserAddressCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id:guid}/delete")]
        public async Task<IActionResult> DeleteUserAddress(Guid id)
        {
            var result = await _mediator.Send(new DeletedUserAdressCommand(id));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserAddress([FromServices] IRequestHandler<EdditedUserAdressCommand, UserAddressDTO> handler, [FromBody] EdditedUserAdressCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}