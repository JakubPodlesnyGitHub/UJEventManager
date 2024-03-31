namespace Shop.API.CQRS.Commands.ProductCategory
{
    public class DeletedProductCategoryCommand : ICommandBase
    {
        public Guid IdProduct { get; set; }
        public Guid IdCategory { get; set; }

        public DeletedProductCategoryCommand(Guid idProduct, Guid idCategory)
        {
            IdProduct = idProduct;
            IdCategory = idCategory;
        }
    }
}