using Shop.API.CQRS.Commands.OrderItem;
using Shop.API.CQRS.Queries.OrderItem;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Handlers
{
    public class OrderItemHandler :
        IQueryBaseHandler<GetOrderItemsQuery, IList<OrderItemDTO>>,
        IQueryBaseHandler<GetOrderItemQueryById, OrderItemDTO>,
        ICommandBaseHandler<AddedOrderItemCommand, OrderItemDTO>,
        ICommandBaseHandler<EditedOrderItemCommand, OrderItemDTO>,
        ICommandBaseHandler<DeletedOrderItemCommand, OrderItemDTO>
    {
        public Task<IList<OrderItemDTO>> HandleAsync(GetOrderItemsQuery command)
        {
            throw new NotImplementedException();
        }

        public Task<OrderItemDTO> HandleAsync(GetOrderItemQueryById command)
        {
            throw new NotImplementedException();
        }

        public Task<OrderItemDTO> HandleAsync(AddedOrderItemCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<OrderItemDTO> HandleAsync(EditedOrderItemCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<OrderItemDTO> HandleAsync(DeletedOrderItemCommand command)
        {
            throw new NotImplementedException();
        }
    }
}