namespace Shop.API.CQRS.Commands.OrderItem
{
    public class AddedOrderItemCommand : ICommandBase
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid IdProduct { get; set; }
        public Guid IdOrder { get; set; }

        public AddedOrderItemCommand(Guid id, int quantity, double price, DateTime creationDate, Guid idProduct, Guid idOrder)
        {
            Id = id;
            Quantity = quantity;
            Price = price;
            CreationDate = creationDate;
            IdProduct = idProduct;
            IdOrder = idOrder;
        }
    }
}