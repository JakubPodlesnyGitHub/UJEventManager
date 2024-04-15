using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.API.CQRS.Commands.Category;
using Shop.API.CQRS.Queries.Category;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var result = await _mediator.Send(new GetCategoriesQuery());
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var result = await _mediator.Send(new GetCategoryByIdQuery(id));
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddCategory([FromBody] AddedCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id:guid}/delete")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var result = await _mediator.Send(new DeletedCategoryCommand(id));
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCategory([FromBody] EditedCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}