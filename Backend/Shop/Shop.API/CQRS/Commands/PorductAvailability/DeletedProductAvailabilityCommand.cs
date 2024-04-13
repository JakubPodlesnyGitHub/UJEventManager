using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Commands.PorductAvailability
{
    public class DeletedProductAvailabilityCommand : IRequest<ProductAvailabilityDTO>
    {
        public Guid Id { get; set; }

        public DeletedProductAvailabilityCommand(Guid id)
        {
            Id = id;
        }
    }
}