using Microsoft.AspNetCore.Mvc;
using Shop.API.CQRS.Commands.Category;
using Shop.API.CQRS.Handlers.Interfaces;
using Shop.API.CQRS.Queries.Category;
using Shop.Shared.Dtos.Response;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCategories([FromServices] IQueryBaseHandler<GetCategoriesQuery, IList<CategoryDTO>> handler)
        {
            var result = await handler.HandleAsync(new GetCategoriesQuery());
            return Ok(result);
        }

        [HttpGet("/{id:guid}")]
        public async Task<IActionResult> GetCategoryById(Guid id, [FromServices] IQueryBaseHandler<GetCategoryByIdQuery, CategoryDTO> handler)
        {
            var result = await handler.HandleAsync(new GetCategoryByIdQuery(id));
            return Ok(result);
        }

        [HttpPost("/create")]
        public async Task<IActionResult> AddCategory([FromServices] ICommandBaseHandler<AddedCategoryCommand, CategoryDTO> handler, [FromBody] AddedCategoryCommand command)
        {
            var result = await handler.HandleAsync(command);
            return Ok(result);
        }

        [HttpDelete("/{id:guid}/delete")]
        public async Task<IActionResult> DeleteCategory(Guid id, [FromServices] ICommandBaseHandler<DeletedCategoryCommand, CategoryDTO> handler)
        {
            var result = await handler.HandleAsync(new DeletedCategoryCommand(id));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromServices] ICommandBaseHandler<EditedCategoryCommand, CategoryDTO> handler, [FromBody] EditedCategoryCommand command)
        {
            var result = await handler.HandleAsync(command);
            return Ok(result);
        }
    }
}