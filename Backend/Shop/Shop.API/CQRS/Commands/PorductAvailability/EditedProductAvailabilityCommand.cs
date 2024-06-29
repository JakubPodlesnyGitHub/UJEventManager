using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Commands.PorductAvailability
{
    public class EditedProductAvailabilityCommand : IRequest<ProductAvailabilityDTO>
    {
        public int Availability { get; set; }
        public Guid IdProduct { get; set; }

        public EditedProductAvailabilityCommand(int availability, Guid idProduct)
        {
            Availability = availability;
            IdProduct = idProduct;
        }
    }
}