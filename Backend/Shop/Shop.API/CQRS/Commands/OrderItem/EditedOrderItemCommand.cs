using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Commands.OrderItem
{
    public class EditedOrderItemCommand : IRequest<OrderItemDTO>
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Guid IdProduct { get; set; }
        public Guid IdOrder { get; set; }

        public EditedOrderItemCommand(Guid id, int quantity, double price, Guid idProduct, Guid idOrder)
        {
            Id = id;
            Quantity = quantity;
            Price = price;
            IdProduct = idProduct;
            IdOrder = idOrder;
        }
    }
}