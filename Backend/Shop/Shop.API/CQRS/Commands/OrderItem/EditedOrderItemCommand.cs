namespace Shop.API.CQRS.Commands.OrderItem
{
    public class EditedOrderItemCommand : ICommandBase
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid IdProduct { get; set; }
        public Guid IdOrder { get; set; }

        public EditedOrderItemCommand(int quantity, double price, DateTime creationDate, Guid idProduct, Guid idOrder)
        {
            Quantity = quantity;
            Price = price;
            CreationDate = creationDate;
            IdProduct = idProduct;
            IdOrder = idOrder;
        }
    }
}