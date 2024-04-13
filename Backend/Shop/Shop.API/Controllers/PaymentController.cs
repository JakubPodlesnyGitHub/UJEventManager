using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.API.CQRS.Commands.Payment;
using Shop.API.CQRS.Queries.Payment;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetPayment()
        {
            var result = await _mediator.Send(new GetPaymentsQuery());
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetPaymentById(Guid id)
        {
            var result = await _mediator.Send(new GetPaymentByIdQuery(id));
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddOrderItem([FromBody] AddedPaymentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id:guid}/delete")]
        public async Task<IActionResult> DeletePayment(Guid id)
        {
            var result = await _mediator.Send(new DeletedPaymentCommand(id));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePayment([FromBody] EditedPaymentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}