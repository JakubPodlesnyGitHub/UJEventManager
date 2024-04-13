using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Commands.OrderItem
{
    public class DeletedOrderItemCommand : IRequest<OrderItemDTO>
    {
        public Guid Id { get; set; }

        public DeletedOrderItemCommand(Guid id)
        {
            Id = id;
        }
    }
}