namespace Shop.API.CQRS.Commands.ProductCategory
{
    public class AddedProductCategoryCommand : ICommandBase
    {
        public Guid IdProduct { get; set; }
        public Guid IdCategory { get; set; }

        public AddedProductCategoryCommand(Guid idProduct, Guid idCategory)
        {
            IdProduct = idProduct;
            IdCategory = idCategory;
        }
    }
}