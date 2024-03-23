namespace Shop.Domain.Domain
{
    public class ProductCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid IdProduct { get; set; }

        public virtual Product ProductNavigation { get; set; }
    }
}