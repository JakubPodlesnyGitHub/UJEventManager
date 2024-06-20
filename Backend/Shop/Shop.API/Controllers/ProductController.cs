using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.API.CQRS.Commands.Product;
using Shop.API.CQRS.Queries.Product;
using Microsoft.AspNetCore.Cors;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("ApiCorsPolicy")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _mediator.Send(new GetProductsQuery());
            return Ok(result);
        }

        [HttpGet("sort/{propertyName}/{order}/{min}/{max}")]
        public async Task<IActionResult> GetSortedProducts([FromRoute] string propertyName, [FromRoute] string order, [FromRoute] double min, [FromRoute] double max)
        {
            var result = await _mediator.Send(new GetSortedProductsQuery(propertyName, order, min, max));
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var result = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddProduct([FromBody] AddedProductCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id:guid}/delete")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var result = await _mediator.Send(new DeletedProductCommand(id));
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateProduct([FromBody] EditedProductCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}