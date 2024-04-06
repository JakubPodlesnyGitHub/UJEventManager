namespace Shop.API.CQRS.Commands.UserAddress
{
    public class AddedUserAddressCommand : ICommandBase
    {
        public string StreetName { get; set; }
        public int BuildingNumber { get; set; }
        public int? ApartmnetNumber { get; set; }
        public string ZipCode { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public Guid IdUser { get; set; }

        public AddedUserAddressCommand(string streetName, int buildingNumber, int? apartmnetNumber, string zipCode, string district, string city, Guid idUser)
        {
            StreetName = streetName;
            BuildingNumber = buildingNumber;
            ApartmnetNumber = apartmnetNumber;
            ZipCode = zipCode;
            District = district;
            City = city;
            IdUser = idUser;
        }
    }
}