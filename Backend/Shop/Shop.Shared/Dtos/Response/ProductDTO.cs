namespace Shop.Shared.Dtos.Response
{
    public class ProductDTO : BasicDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string CodeNumber { get; set; }
        public string SeriesNumber { get; set; }
        public string? Description { get; set; }
        public string? Picture { get; set; }
        public double? Rate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime CreationDate { get; set; }
        public IList<ProductAvailabilityDTO> ProductAvailabilities { get; set; }
        public IList<ProductCategoryDTO> ProductCategories { get; set; }
        public IList<OrderItemDTO> OrderItems { get; set; }
    }
}