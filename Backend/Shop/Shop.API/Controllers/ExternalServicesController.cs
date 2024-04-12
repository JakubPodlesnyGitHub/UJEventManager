using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shop.API.CQRS.Handlers.Interfaces;
using Shop.API.CQRS.Queries.Category;
using Shop.API.CQRS.Queries.ExternalServices;
using Shop.Domain.Enums;
using Shop.Infrastructure.Models;
using Shop.Shared.Dtos.ExternalServices;
using Shop.Shared.Dtos.Response;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalServicesController : ControllerBase
    {

        [HttpGet("/currencies")]
        public IActionResult GetSupportedCurrencies()
        {
            return Ok(new List<string>(){
                SupportedCurrency.USD.ToString(),
                SupportedCurrency.EUR.ToString(),
                SupportedCurrency.CZK.ToString(),
                SupportedCurrency.GBP.ToString()});
        }

        [HttpGet("/currency-rate/{code}")]
        public async Task<IActionResult> GetCurrencyRate(string code, [FromServices] IQueryBaseHandler<GetCurrencyRateQuery, RateDTO> handler)
        {
            var result = await handler.HandleAsync(new GetCurrencyRateQuery(code));
            if (result is null)
            {
                NotFound("There is no available rate for provided currency.");
            }
            return Ok(result);
        }
    }
}
