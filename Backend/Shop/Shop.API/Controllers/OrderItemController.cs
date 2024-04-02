using Microsoft.AspNetCore.Mvc;
using Shop.API.CQRS.Commands.OrderItem;
using Shop.API.CQRS.Handlers.Interfaces;
using Shop.API.CQRS.Queries.OrderItem;
using Shop.Shared.Dtos.Response;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetOrderItem([FromServices] IQueryBaseHandler<GetOrderItemsQuery, IList<OrderItemDTO>> handler)
        {
            var result = await handler.HandleAsync(new GetOrderItemsQuery());
            return Ok(result);
        }

        [HttpGet("/{id:guid}")]
        public async Task<IActionResult> GetOrderItemById(Guid id, [FromServices] IQueryBaseHandler<GetOrderItemQueryById, OrderItemDTO> handler)
        {
            var result = await handler.HandleAsync(new GetOrderItemQueryById(id));
            return Ok(result);
        }

        [HttpPost("/create")]
        public async Task<IActionResult> AddOrderItem([FromServices] ICommandBaseHandler<AddedOrderItemCommand, OrderItemDTO> handler, [FromBody] AddedOrderItemCommand command)
        {
            var result = await handler.HandleAsync(command);
            return Ok(result);
        }

        [HttpDelete("/{id:guid}/delete")]
        public async Task<IActionResult> DeleteOrderItem(Guid id, [FromServices] ICommandBaseHandler<DeletedOrderItemCommand, OrderItemDTO> handler)
        {
            var result = await handler.HandleAsync(new DeletedOrderItemCommand(id));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderItem([FromServices] ICommandBaseHandler<EditedOrderItemCommand, OrderItemDTO> handler, [FromBody] EditedOrderItemCommand command)
        {
            var result = await handler.HandleAsync(command);
            return Ok(result);
        }
    }
}