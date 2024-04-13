using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.API.CQRS.Commands.OrderItem;
using Shop.API.CQRS.Queries.OrderItem;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderItem()
        {
            var result = await _mediator.Send(new GetOrderItemsQuery());
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOrderItemById(Guid id)
        {
            var result = await _mediator.Send(new GetOrderItemQueryById(id));
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddOrderItem([FromBody] AddedOrderItemCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id:guid}/delete")]
        public async Task<IActionResult> DeleteOrderItem(Guid id)
        {
            var result = await _mediator.Send(new DeletedOrderItemCommand(id));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderItem([FromBody] EditedOrderItemCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}