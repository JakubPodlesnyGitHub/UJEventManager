namespace Shop.Domain.Domain
{
    public class UserAddress
    {
        public Guid Id { get; set; }
        public string StreetName { get; set; }
        public int BuildingNumber { get; set; }
        public int? ApartmnetNumber { get; set; }
        public string ZipCode { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public Guid IdUser { get; set; }

        public virtual User UserNavigation { get; set; }
    }
}