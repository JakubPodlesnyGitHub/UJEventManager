namespace Shop.API.CQRS.Commands.UserAddress
{
    public class EdditedUserAdressCommand : ICommandBase
    {
        public Guid Id { get; set; }
        public string StreetName { get; set; }
        public int BuildingNumber { get; set; }
        public int? ApartmnetNumber { get; set; }
        public string ZipCode { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public Guid IdUser { get; set; }

        public EdditedUserAdressCommand(Guid id, string streetName, int buildingNumber, int? apartmnetNumber, string zipCode, string district, string city, Guid idUser)
        {
            Id = id;
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