using Microsoft.AspNetCore.Mvc;
using Shop.API.CQRS.Commands.PorductAvailability;
using Shop.API.CQRS.Handlers.Interfaces;
using Shop.API.CQRS.Queries.PorductAvailability;
using Shop.Shared.Dtos.Response;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAvailabilityController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetProductAvailabilites([FromServices] IQueryBaseHandler<GetProductAvailabilitiesQuery, IList<ProductAvailabilityDTO>> handler)
        {
            var result = await handler.HandleAsync(new GetProductAvailabilitiesQuery());
            return Ok(result);
        }

        [HttpGet("/{id:guid}")]
        public async Task<IActionResult> GetProductAvailabilityById(Guid id, [FromServices] IQueryBaseHandler<GetProductAvailabilityByIdQuery, ProductAvailabilityDTO> handler)
        {
            var result = await handler.HandleAsync(new GetProductAvailabilityByIdQuery(id));
            return Ok(result);
        }

        [HttpPost("/create")]
        public async Task<IActionResult> AddProductAvailability([FromServices] ICommandBaseHandler<AddedProductAvailabilityCommand, ProductAvailabilityDTO> handler, [FromBody] AddedProductAvailabilityCommand command)
        {
            var result = await handler.HandleAsync(command);
            return Ok(result);
        }

        [HttpDelete("/{id:guid}/delete")]
        public async Task<IActionResult> DeleteProductAvailability(Guid id, [FromServices] ICommandBaseHandler<DeletedProductAvailabilityCommand, ProductAvailabilityDTO> handler)
        {
            var result = await handler.HandleAsync(new DeletedProductAvailabilityCommand(id));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductAvailability([FromServices] ICommandBaseHandler<EditedProductAvailabilityCommand, PaymentDTO> handler, [FromBody] EditedProductAvailabilityCommand command)
        {
            var result = await handler.HandleAsync(command);
            return Ok(result);
        }
    }
}