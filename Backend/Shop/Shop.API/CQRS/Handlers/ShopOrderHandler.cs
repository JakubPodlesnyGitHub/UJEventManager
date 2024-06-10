using AutoMapper;
using MediatR;
using Shop.API.CQRS.Commands.ShopOrder;
using Shop.API.CQRS.Queries.ShopOrder;
using Shop.Domain.Domain;
using Shop.Infrastructure.Repositories.Interfaces;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Handlers
{
    public class ShopOrderHandler :
        IRequestHandler<GetShopOrdersQuery, IList<ShopOrderDTO>>,
        IRequestHandler<GetShopOrderByIdQuery, ShopOrderDTO>,
        IRequestHandler<AddedShopOrderCommand, ShopOrderDTO>,
        IRequestHandler<EditedShopOrderCommand, ShopOrderDTO>,
        IRequestHandler<DeletedShopOrderCommand, ShopOrderDTO>
    {
        private readonly IShopOrderRepository _shopOrderRepository;
        private readonly IMapper _mapper;

        public ShopOrderHandler(IShopOrderRepository shopOrderRepository, IMapper mapper)
        {
            _shopOrderRepository = shopOrderRepository;
            _mapper = mapper;
        }

        public async Task<IList<ShopOrderDTO>> Handle(GetShopOrdersQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IList<ShopOrderDTO>>(await _shopOrderRepository.GetAll());
        }

        public async Task<ShopOrderDTO> Handle(GetShopOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var searchShopOrder = await _shopOrderRepository.GetById(request.Id);
            if (searchShopOrder is null)
            {
                throw new NotImplementedException();
            }
            return _mapper.Map<ShopOrderDTO>(searchShopOrder);
        }

        public async Task<ShopOrderDTO> Handle(AddedShopOrderCommand request, CancellationToken cancellationToken)
        {
            var category = _shopOrderRepository.Insert(_mapper.Map<ShopOrder>(request));
            await _shopOrderRepository.Commit();
            return _mapper.Map<ShopOrderDTO>(category);
        }

        public async Task<ShopOrderDTO> Handle(EditedShopOrderCommand request, CancellationToken cancellationToken)
        {
            var shopOrder = await _shopOrderRepository.GetById(request.Id) ?? throw new NotImplementedException();
            if (request.Name is not null)
            {
                shopOrder.Name = request.Name;
            }
            if (request.OrderCode is not null && !request.OrderCode.Equals(shopOrder.OrderCode))
            {
                shopOrder.OrderCode = request.OrderCode;
            }
            if (request.ExpectedLeadTime != shopOrder.ExpectedLeadTime)
            {
                shopOrder.ExpectedLeadTime = request.ExpectedLeadTime;
            }
            if (!request.Total.Equals(shopOrder.Total))
            {
                shopOrder.Total = request.Total;
            }
            if (!request.Status.Equals(shopOrder.Status))
            {
                shopOrder.Status = request.Status.ToString();
            }
            shopOrder.IdOrderAddress = request.IdOrderAddress;
            shopOrder.IdPayment = request.IdPayment;

            _shopOrderRepository.Update(shopOrder);
            await _shopOrderRepository.Commit();
            return _mapper.Map<ShopOrderDTO>(shopOrder);
        }

        public async Task<ShopOrderDTO> Handle(DeletedShopOrderCommand request, CancellationToken cancellationToken)
        {
            var shopOrder = await _shopOrderRepository.GetById(request.Id) ?? throw new NotImplementedException();
            await _shopOrderRepository.Delete(shopOrder.Id);
            return _mapper.Map<ShopOrderDTO>(shopOrder);
        }
    }
}