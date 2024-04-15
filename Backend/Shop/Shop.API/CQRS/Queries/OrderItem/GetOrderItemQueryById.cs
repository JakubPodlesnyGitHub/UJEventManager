using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Queries.OrderItem
{
    public class GetOrderItemQueryById : IRequest<OrderItemDTO>
    {
        public Guid Id { get; set; }

        public GetOrderItemQueryById(Guid id)
        {
            Id = id;
        }
    }
}