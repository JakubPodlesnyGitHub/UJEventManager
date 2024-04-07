namespace Shop.Shared.Dtos.Response
{
    public class OrderAddressDTO : BasicDTO
    {
        public Guid Id { get; set; }
        public string StreetName { get; set; }
        public int BuildingNumber { get; set; }
        public int? ApartmentNumber { get; set; }
        public string ZipCode { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public IList<ShopOrderDTO> ShopOrders { get; set; }
    }
}