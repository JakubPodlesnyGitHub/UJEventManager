using MediatR;
using Shop.Shared.Dtos.ExternalServices;

namespace Shop.API.CQRS.Queries.ExternalServices
{
    public class GetCurrencyRateQuery : IRequest<RateDTO>
    {
        public string CurrencyCode { get; set; }

        public GetCurrencyRateQuery(string code)
        {
            CurrencyCode = code;
        }
    }
}