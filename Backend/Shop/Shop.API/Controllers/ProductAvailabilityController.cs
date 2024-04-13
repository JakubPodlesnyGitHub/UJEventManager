using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.API.CQRS.Commands.PorductAvailability;
using Shop.API.CQRS.Queries.PorductAvailability;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAvailabilityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductAvailabilityController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductAvailabilites()
        {
            var result = await _mediator.Send(new GetProductAvailabilitiesQuery());
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetProductAvailabilityById(Guid id)
        {
            var result = await _mediator.Send(new GetProductAvailabilityByIdQuery(id));
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddProductAvailability([FromBody] AddedProductAvailabilityCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id:guid}/delete")]
        public async Task<IActionResult> DeleteProductAvailability(Guid id)
        {
            var result = await _mediator.Send(new DeletedProductAvailabilityCommand(id));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductAvailability([FromBody] EditedProductAvailabilityCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}