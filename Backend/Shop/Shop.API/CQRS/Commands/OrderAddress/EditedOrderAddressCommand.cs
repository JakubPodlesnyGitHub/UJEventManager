using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Commands.OrderAddress
{
    public class EditedOrderAddressCommand : IRequest<OrderAddressDTO>
    {
        public Guid Id { get; set; }
        public string StreetName { get; set; }
        public int BuildingNumber { get; set; }
        public int? ApartmentNumber { get; set; }
        public string ZipCode { get; set; }
        public string District { get; set; }
        public string City { get; set; }

        public EditedOrderAddressCommand(Guid id, string streetName, int buildingNumber, int? apartmentNumber, string zipCode, string district, string city)
        {
            Id = id;
            StreetName = streetName;
            BuildingNumber = buildingNumber;
            ApartmentNumber = apartmentNumber;
            ZipCode = zipCode;
            District = district;
            City = city;
        }
    }
}