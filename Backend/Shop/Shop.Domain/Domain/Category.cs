namespace Shop.Domain.Domain
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProductCategory> ProductCategoriesNavigation { get; set; }
    }
}