namespace Shop.Domain.Domain
{
    public class ProductAvailability
    {
        public Guid Id { get; set; }
        public int Availability { get; set; }
        public string Status { get; set; }
        public DateTime SnapshotStatusTime { get; set; }
        public Guid IdProduct { get; set; }

        public virtual Product ProductNavigation { get; set; }
    }
}