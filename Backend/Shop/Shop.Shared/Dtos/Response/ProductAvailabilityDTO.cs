namespace Shop.Shared.Dtos.Response
{
    public class ProductAvailabilityDTO : BasicDTO
    {
        public Guid Id { get; set; }
        public int Availability { get; set; }
        public string Status { get; set; }
        public DateTime SnapshotStatusTime { get; set; }
        public ProductDTO Product { get; set; }
    }
}