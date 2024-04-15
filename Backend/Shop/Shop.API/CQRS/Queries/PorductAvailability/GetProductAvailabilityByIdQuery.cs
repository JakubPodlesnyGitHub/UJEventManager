using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Queries.PorductAvailability
{
    public class GetProductAvailabilityByIdQuery : IRequest<ProductAvailabilityDTO>
    {
        public Guid Id { get; set; }

        public GetProductAvailabilityByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}