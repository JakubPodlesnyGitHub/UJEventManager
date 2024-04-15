using MediatR;
using Shop.Domain.Enums;

namespace Shop.API.CQRS.Queries.ExternalServices
{
    public class GetSupportedCurrenciesQuery : IRequest<IList<SupportedCurrency>>
    {
    }
}