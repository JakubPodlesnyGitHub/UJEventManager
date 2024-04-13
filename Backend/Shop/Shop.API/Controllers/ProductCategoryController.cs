using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.API.CQRS.Commands.ProductCategory;
using Shop.API.CQRS.Commands.UserAddress;
using Shop.API.CQRS.Queries.ProductCategory;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        public readonly IMediator _mediator;

        public ProductCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsCategories()
        {
            var result = await _mediator.Send(new GetProductsCategoriesQuery());
            return Ok(result);
        }

        [HttpGet("product-category")]
        public async Task<IActionResult> GetProductCategoryByIds(GetProdcutCategoryByIdsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddProductCategory([FromBody] AddedProductCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductCategory([FromBody] DeletedProductCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductCategory([FromBody] EdditedUserAdressCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}