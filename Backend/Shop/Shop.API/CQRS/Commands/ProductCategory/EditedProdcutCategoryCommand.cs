namespace Shop.API.CQRS.Commands.ProductCategory
{
    public class EditedProdcutCategoryCommand : ICommandBase
    {
        public Guid IdProduct { get; set; }
        public Guid IdCategory { get; set; }

        public EditedProdcutCategoryCommand(Guid idProduct, Guid idCategory)
        {
            IdProduct = idProduct;
            IdCategory = idCategory;
        }
    }
}