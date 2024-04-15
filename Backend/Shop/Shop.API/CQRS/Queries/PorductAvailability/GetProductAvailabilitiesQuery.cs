using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Queries.PorductAvailability
{
    public class GetProductAvailabilitiesQuery : IRequest<IList<ProductAvailabilityDTO>>
    {
    }
}