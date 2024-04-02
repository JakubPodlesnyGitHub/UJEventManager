using Microsoft.AspNetCore.Mvc;
using Shop.API.CQRS.Commands.Payment;
using Shop.API.CQRS.Handlers.Interfaces;
using Shop.API.CQRS.Queries.Payment;
using Shop.Shared.Dtos.Response;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetPayment([FromServices] IQueryBaseHandler<GetPaymentsQuery, IList<PaymentDTO>> handler)
        {
            var result = await handler.HandleAsync(new GetPaymentsQuery());
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetPaymentById(Guid id, [FromServices] IQueryBaseHandler<GetPaymentByIdQuery, PaymentDTO> handler)
        {
            var result = await handler.HandleAsync(new GetPaymentByIdQuery(id));
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddOrderItem([FromServices] ICommandBaseHandler<AddedPaymentCommand, PaymentDTO> handler, [FromBody] AddedPaymentCommand command)
        {
            var result = await handler.HandleAsync(command);
            return Ok(result);
        }

        [HttpDelete("{id:guid}/delete")]
        public async Task<IActionResult> DeletePayment(Guid id, [FromServices] ICommandBaseHandler<DeletedPaymentCommand, PaymentDTO> handler)
        {
            var result = await handler.HandleAsync(new DeletedPaymentCommand(id));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePayment([FromServices] ICommandBaseHandler<EditedPaymentCommand, PaymentDTO> handler, [FromBody] EditedPaymentCommand command)
        {
            var result = await handler.HandleAsync(command);
            return Ok(result);
        }
    }
}