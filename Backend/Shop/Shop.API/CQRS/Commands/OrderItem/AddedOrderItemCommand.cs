using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Commands.OrderItem
{
    public class AddedOrderItemCommand : IRequest<OrderItemDTO>
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Guid IdProduct { get; set; }
        public Guid IdOrder { get; set; }

        public AddedOrderItemCommand(int quantity, double price, Guid idProduct, Guid idOrder)
        {
            Quantity = quantity;
            Price = price;
            IdProduct = idProduct;
            IdOrder = idOrder;
        }
    }
}