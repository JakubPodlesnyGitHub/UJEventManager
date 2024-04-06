using Microsoft.AspNetCore.Mvc;
using Shop.API.CQRS.Commands.ShopOrder;
using Shop.API.CQRS.Handlers.Interfaces;
using Shop.API.CQRS.Queries.ShopOrder;
using Shop.Shared.Dtos.Response;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopOrderController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetShopOrders([FromServices] IQueryBaseHandler<GetShopOrdersQuery, IList<ShopOrderDTO>> handler)
        {
            var result = await handler.HandleAsync(new GetShopOrdersQuery());
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetShopOrderById(Guid id, [FromServices] IQueryBaseHandler<GetShopOrderByIdQuery, ShopOrderDTO> handler)
        {
            var result = await handler.HandleAsync(new GetShopOrderByIdQuery(id));
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddShopOrder([FromServices] ICommandBaseHandler<AddedShopOrderCommand, ShopOrderDTO> handler, [FromBody] AddedShopOrderCommand command)
        {
            var result = await handler.HandleAsync(command);
            return Ok(result);
        }

        [HttpDelete("{id:guid}/delete")]
        public async Task<IActionResult> DeleteShopOrder(Guid id, [FromServices] ICommandBaseHandler<DeletedShopOrderCommand, ShopOrderDTO> handler)
        {
            var result = await handler.HandleAsync(new DeletedShopOrderCommand(id));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateShopOrder([FromServices] ICommandBaseHandler<EditedShopOrderCommand, ShopOrderDTO> handler, [FromBody] EditedShopOrderCommand command)
        {
            var result = await handler.HandleAsync(command);
            return Ok(result);
        }
    }
}