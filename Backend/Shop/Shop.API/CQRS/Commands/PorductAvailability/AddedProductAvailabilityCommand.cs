using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Commands.PorductAvailability
{
    public class AddedProductAvailabilityCommand : IRequest<ProductAvailabilityDTO>
    {
        public int Availability { get; set; }
        public string Status { get; set; }
        public Guid IdProduct { get; set; }

        public AddedProductAvailabilityCommand(int availability, string status, Guid idProduct)
        {
            Availability = availability;
            Status = status;
            IdProduct = idProduct;
        }
    }
}