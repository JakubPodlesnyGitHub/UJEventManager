using AutoMapper;
using MediatR;
using Shop.API.CQRS.Commands.OrderItem;
using Shop.API.CQRS.Queries.OrderItem;
using Shop.Domain.Domain;
using Shop.Infrastructure.Repositories.Interfaces;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Handlers
{
    public class OrderItemHandler :
        IRequestHandler<GetOrderItemsQuery, IList<OrderItemDTO>>,
        IRequestHandler<GetOrderItemQueryById, OrderItemDTO>,
        IRequestHandler<AddedOrderItemCommand, OrderItemDTO>,
        IRequestHandler<EditedOrderItemCommand, OrderItemDTO>,
        IRequestHandler<DeletedOrderItemCommand, OrderItemDTO>
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public OrderItemHandler(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public async Task<IList<OrderItemDTO>> Handle(GetOrderItemsQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IList<OrderItemDTO>>(await _orderItemRepository.GetOrderItemsWithOrdersAndProducts());
        }

        public async Task<OrderItemDTO> Handle(GetOrderItemQueryById request, CancellationToken cancellationToken)
        {
            var searchOrderItem = await _orderItemRepository.GetOrderItemByIdWithOrdersAndProducts(request.Id);
            if (searchOrderItem is null)
            {
                throw new NotImplementedException();
            }
            return _mapper.Map<OrderItemDTO>(searchOrderItem);
        }

        public async Task<OrderItemDTO> Handle(AddedOrderItemCommand request, CancellationToken cancellationToken)
        {
            var orderItem = _orderItemRepository.Insert(_mapper.Map<OrderItem>(request));
            await _orderItemRepository.Commit();
            return _mapper.Map<OrderItemDTO>(orderItem);
        }

        public async Task<OrderItemDTO> Handle(EditedOrderItemCommand request, CancellationToken cancellationToken)
        {
            var orderItem = await _orderItemRepository.GetById(request.Id);
            if (orderItem is null)
            {
                throw new NotImplementedException();
            }
            orderItem.Price = request.Price;
            orderItem.Quantity = request.Quantity;
            orderItem.IdProduct = request.IdProduct;
            orderItem.IdOrder = request.IdOrder;

            _orderItemRepository.Update(orderItem);
            await _orderItemRepository.Commit();

            return _mapper.Map<OrderItemDTO>(orderItem);
        }

        public async Task<OrderItemDTO> Handle(DeletedOrderItemCommand request, CancellationToken cancellationToken)
        {
            var orderItem = await _orderItemRepository.GetById(request.Id);
            if (orderItem is null)
            {
                throw new NotImplementedException();
            }

            await _orderItemRepository.Delete(orderItem.Id);
            await _orderItemRepository.Commit();
            return _mapper.Map<OrderItemDTO>(orderItem);
        }
    }
}