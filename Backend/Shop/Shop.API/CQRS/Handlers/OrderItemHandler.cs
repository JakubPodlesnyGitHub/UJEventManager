using AutoMapper;
using Shop.API.CQRS.Commands.OrderItem;
using Shop.API.CQRS.Handlers.Interfaces;
using Shop.API.CQRS.Queries.OrderItem;
using Shop.Domain.Domain;
using Shop.Infrastructure.Repositories.Interfaces;
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
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public OrderItemHandler(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public async Task<IList<OrderItemDTO>> HandleAsync(GetOrderItemsQuery command)
        {
            return _mapper.Map<IList<OrderItemDTO>>(await _orderItemRepository.GetOrderItemsWithOrdersAndProducts());
        }

        public async Task<OrderItemDTO> HandleAsync(GetOrderItemQueryById command)
        {
            var searchOrderItem = await _orderItemRepository.GetOrderItemByIdWithOrdersAndProducts(command.Id);
            if (searchOrderItem is null)
            {
                throw new NotImplementedException();
            }
            return _mapper.Map<OrderItemDTO>(searchOrderItem);
        }

        public async Task<OrderItemDTO> HandleAsync(AddedOrderItemCommand command)
        {
            var orderItem = _orderItemRepository.Insert(_mapper.Map<OrderItem>(command));
            await _orderItemRepository.Commit();
            return _mapper.Map<OrderItemDTO>(orderItem);
        }

        public async Task<OrderItemDTO> HandleAsync(EditedOrderItemCommand command)
        {
            var orderItem = await _orderItemRepository.GetById(command.Id);
            if (orderItem is null)
            {
                throw new NotImplementedException();
            }
            orderItem.Price = command.Price;
            orderItem.Quantity = command.Quantity;
            orderItem.IdProduct = command.IdProduct;
            orderItem.IdOrder = command.IdOrder;

            _orderItemRepository.Update(orderItem);
            await _orderItemRepository.Commit();

            return _mapper.Map<OrderItemDTO>(orderItem);
        }

        public async Task<OrderItemDTO> HandleAsync(DeletedOrderItemCommand command)
        {
            var orderItem = await _orderItemRepository.GetById(command.Id);
            if (orderItem is null)
            {
                throw new NotImplementedException();
            }

            await _orderItemRepository.Delete(orderItem);
            await _orderItemRepository.Commit();
            return _mapper.Map<OrderItemDTO>(orderItem);
        }
    }
}