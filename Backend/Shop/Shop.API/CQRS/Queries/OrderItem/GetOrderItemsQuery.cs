using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Queries.OrderItem
{
    public class GetOrderItemsQuery : IRequest<IList<OrderItemDTO>>
    {
    }
}