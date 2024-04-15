using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.API.CQRS.Commands.OrderAddress;
using Shop.API.CQRS.Queries.OrderAddress;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderAddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderAddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderAddresses()
        {
            var result = await _mediator.Send(new GetOrderAdderssesQuery());
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOrderAddressById(Guid id)
        {
            var result = await _mediator.Send(new GetOrderAddressByIdQuery(id));
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddOrderAddress([FromBody] AddedOrderAddressCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id:guid}/delete")]
        public async Task<IActionResult> DeleteOrderAddress(Guid id)
        {
            var result = await _mediator.Send(new DeletedOrderAddressCommand(id));
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateOrderAddress([FromBody] EditedOrderAddressCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}