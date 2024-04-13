using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.API.CQRS.Queries.ExternalServices;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalServicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExternalServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/currencies")]
        public async Task<IActionResult> GetSupportedCurrencies()
        {
            return Ok(await _mediator.Send(GetSupportedCurrencies()));
        }

        [HttpGet("/currency-rate/{code}")]
        public async Task<IActionResult> GetCurrencyRate(string code)
        {
            var result = await _mediator.Send(new GetCurrencyRateQuery(code));
            if (result is null)
            {
                NotFound("There is no available rate for provided currency.");
            }
            return Ok(result);
        }
    }
}