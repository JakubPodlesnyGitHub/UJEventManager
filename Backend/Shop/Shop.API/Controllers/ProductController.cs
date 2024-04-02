using Microsoft.AspNetCore.Mvc;
using Shop.API.CQRS.Commands.Product;
using Shop.API.CQRS.Handlers.Interfaces;
using Shop.API.CQRS.Queries.Product;
using Shop.Shared.Dtos.Response;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromServices] IQueryBaseHandler<GetProductsQuery, IList<ProductDTO>> handler)
        {
            var result = await handler.HandleAsync(new GetProductsQuery());
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetProductById(Guid id, [FromServices] IQueryBaseHandler<GetProductByIdQuery, ProductDTO> handler)
        {
            var result = await handler.HandleAsync(new GetProductByIdQuery(id));
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddProduct([FromServices] ICommandBaseHandler<AddedProductCommand, ProductDTO> handler, [FromBody] AddedProductCommand command)
        {
            var result = await handler.HandleAsync(command);
            return Ok(result);
        }

        [HttpDelete("{id:guid}/delete")]
        public async Task<IActionResult> DeleteProduct(Guid id, [FromServices] ICommandBaseHandler<DeletedProductCommand, ProductDTO> handler)
        {
            var result = await handler.HandleAsync(new DeletedProductCommand(id));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromServices] ICommandBaseHandler<EditedProductCommand, ProductDTO> handler, [FromBody] EditedProductCommand command)
        {
            var result = await handler.HandleAsync(command);
            return Ok(result);
        }
    }
}