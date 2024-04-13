namespace Shop.Shared.Dtos.Response
{
    public class ProductCategoryDTO : BasicDTO
    {

        public DateTime CreationDate { get; set; }
        public CategoryDTO Category { get; set; }
        public ProductDTO Product { get; set; }
    }
}