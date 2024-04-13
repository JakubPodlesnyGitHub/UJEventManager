using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.API.CQRS.Commands.ShopOrder;
using Shop.API.CQRS.Queries.ShopOrder;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopOrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShopOrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetShopOrders()
        {
            var result = await _mediator.Send(new GetShopOrdersQuery());
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetShopOrderById(Guid id)
        {
            var result = await _mediator.Send(new GetShopOrderByIdQuery(id));
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddShopOrder([FromBody] AddedShopOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id:guid}/delete")]
        public async Task<IActionResult> DeleteShopOrder(Guid id)
        {
            var result = await _mediator.Send(new DeletedShopOrderCommand(id));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateShopOrder([FromBody] EditedShopOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}