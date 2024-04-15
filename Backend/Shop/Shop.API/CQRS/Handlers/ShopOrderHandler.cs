using AutoMapper;
using MediatR;
using Shop.API.CQRS.Commands.Category;
using Shop.API.CQRS.Commands.ShopOrder;
using Shop.API.CQRS.Queries.Category;
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
            shopOrder.Name = request.Name;
            shopOrder.OrderCode = request.OrderCode;
            shopOrder.Status = request.Status.ToString();
            shopOrder.ExpectedLeadTime = request.ExpectedLeadTime;
            _shopOrderRepository.Update(shopOrder);
            await _shopOrderRepository.Commit();
            return _mapper.Map<ShopOrderDTO>(shopOrder);
        }

        public async Task<ShopOrderDTO> Handle(DeletedShopOrderCommand request, CancellationToken cancellationToken)
        {
            var shopOrder = await _shopOrderRepository.GetById(request.Id);
            if (shopOrder is null)
            {
                throw new NotImplementedException();
            }
            await _shopOrderRepository.Delete(shopOrder);
            return _mapper.Map<ShopOrderDTO>(shopOrder);
        }
    }
}
