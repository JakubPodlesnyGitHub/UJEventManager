using Microsoft.AspNetCore.Mvc;
using Shop.API.CQRS.Commands.OrderAddress;
using Shop.API.CQRS.Handlers.Interfaces;
using Shop.API.CQRS.Queries.OrderAddress;
using Shop.Shared.Dtos.Response;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderAddressController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetOrderAddresses([FromServices] IQueryBaseHandler<GetOrderAdderssesQuery, IList<OrderAddressDTO>> handler)
        {
            var result = await handler.HandleAsync(new GetOrderAdderssesQuery());
            return Ok(result);
        }

        [HttpGet("/{id:guid}")]
        public async Task<IActionResult> GetOrderAddressById(Guid id, [FromServices] IQueryBaseHandler<GetOrderAddressByIdQuery, OrderAddressDTO> handler)
        {
            var result = await handler.HandleAsync(new GetOrderAddressByIdQuery(id));
            return Ok(result);
        }

        [HttpPost("/create")]
        public async Task<IActionResult> AddOrderAddress([FromServices] ICommandBaseHandler<AddedOrderAddressCommand, OrderAddressDTO> handler, [FromBody] AddedOrderAddressCommand command)
        {
            var result = await handler.HandleAsync(command);
            return Ok(result);
        }

        [HttpDelete("/{id:guid}/delete")]
        public async Task<IActionResult> DeleteOrderAddress(Guid id, [FromServices] ICommandBaseHandler<DeletedOrderAddressCommand, OrderAddressDTO> handler)
        {
            var result = await handler.HandleAsync(new DeletedOrderAddressCommand(id));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderAddress([FromServices] ICommandBaseHandler<EditedOrderAddressCommand, OrderAddressDTO> handler, [FromBody] EditedOrderAddressCommand command)
        {
            var result = await handler.HandleAsync(command);
            return Ok(result);
        }
    }
}