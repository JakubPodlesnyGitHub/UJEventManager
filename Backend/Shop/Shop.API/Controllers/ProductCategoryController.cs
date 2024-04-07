using Microsoft.AspNetCore.Mvc;
using Shop.API.CQRS.Commands.ProductCategory;
using Shop.API.CQRS.Commands.UserAddress;
using Shop.API.CQRS.Handlers.Interfaces;
using Shop.API.CQRS.Queries.ProductCategory;
using Shop.Shared.Dtos.Response;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetProductsCategories([FromServices] IQueryBaseHandler<GetProductsCategoriesQuery, IList<ProductCategoryDTO>> handler)
        {
            var result = await handler.HandleAsync(new GetProductsCategoriesQuery());
            return Ok(result);
        }

        [HttpGet("product-category")]
        public async Task<IActionResult> GetProductCategoryByIds([FromServices] IQueryBaseHandler<GetProdcutCategoryByIdsQuery, ProductCategoryDTO> handler, GetProdcutCategoryByIdsQuery query)
        {
            var result = await handler.HandleAsync(query);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddProductCategory([FromServices] ICommandBaseHandler<AddedProductCategoryCommand, ProductCategoryDTO> handler, [FromBody] AddedProductCategoryCommand command)
        {
            var result = await handler.HandleAsync(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductCategory([FromServices] ICommandBaseHandler<DeletedProductCategoryCommand, ProductCategoryDTO> handler, [FromBody] DeletedProductCategoryCommand command)
        {
            var result = await handler.HandleAsync(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductCategory([FromServices] ICommandBaseHandler<EdditedUserAdressCommand, UserAddressDTO> handler, [FromBody] EdditedUserAdressCommand command)
        {
            var result = await handler.HandleAsync(command);
            return Ok(result);
        }
    }
}