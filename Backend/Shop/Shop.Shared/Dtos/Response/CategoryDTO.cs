namespace Shop.Shared.Dtos.Response
{
    public class CategoryDTO : BasicDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<ProductCategoryDTO> ProductCategories { get; set; }
    }
}