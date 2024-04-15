namespace Shop.Domain.Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CodeNumber { get; set; }
        public string SeriesNumber { get; set; }
        public string? Description { get; set; }
        public string? Picture { get; set; }
        public double? Rate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual ICollection<ProductCategory> ProductCategoriesNavigation { get; set; }
        public virtual ICollection<ProductAvailability> ProductAvailabilitiesNavigation { get; set; }
        public virtual ICollection<OrderItem> OrderItemsNavigation { get; set; }
    }
}