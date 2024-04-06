namespace Shop.Shared.Dtos.Response
{
    public class UserAddressDTO : BasicDTO
    {
        public Guid Id { get; set; }
        public string StreetName { get; set; }
        public int BuildingNumber { get; set; }
        public int? ApartmnetNumber { get; set; }
        public string ZipCode { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public UserDTO User { get; set; }
    }
}