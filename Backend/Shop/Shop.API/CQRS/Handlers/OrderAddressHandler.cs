using AutoMapper;
using MediatR;
using Shop.API.CQRS.Commands.OrderAddress;
using Shop.API.CQRS.Queries.OrderAddress;
using Shop.Domain.Domain;
using Shop.Infrastructure.Repositories.Interfaces;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Handlers
{
    public class OrderAddressHandler :
        IRequestHandler<GetOrderAdderssesQuery, IList<OrderAddressDTO>>,
        IRequestHandler<GetOrderAddressByIdQuery, OrderAddressDTO>,
        IRequestHandler<AddedOrderAddressCommand, OrderAddressDTO>,
        IRequestHandler<EditedOrderAddressCommand, OrderAddressDTO>,
        IRequestHandler<DeletedOrderAddressCommand, OrderAddressDTO>
    {
        private readonly IOrderAddressRepository _orderAddressRepository;
        private readonly IMapper _mapper;

        public OrderAddressHandler(IOrderAddressRepository orderAddressRepository, IMapper mapper)
        {
            _orderAddressRepository = orderAddressRepository;
            _mapper = mapper;
        }

        public async Task<IList<OrderAddressDTO>> Handle(GetOrderAdderssesQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IList<OrderAddressDTO>>(await _orderAddressRepository.GetOrderAddressesWithShopOrders());
        }

        public async Task<OrderAddressDTO> Handle(GetOrderAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var searchOrderAddress = await _orderAddressRepository.GetOrderAddressByIdWithShopOrders(request.Id);
            if (searchOrderAddress is null)
            {
                throw new NotImplementedException();
            }
            return _mapper.Map<OrderAddressDTO>(searchOrderAddress);
        }

        public async Task<OrderAddressDTO> Handle(AddedOrderAddressCommand request, CancellationToken cancellationToken)
        {
            _orderAddressRepository.Insert(_mapper.Map<OrderAddress>(request));
            await _orderAddressRepository.Commit();
            return _mapper.Map<OrderAddressDTO>(request);
        }

        public async Task<OrderAddressDTO> Handle(EditedOrderAddressCommand request, CancellationToken cancellationToken)
        {
            var orderAddress = await _orderAddressRepository.GetById(request.Id);
            if (orderAddress is null)
            {
                throw new NotImplementedException();
            }

            orderAddress.StreetName = request.StreetName;
            orderAddress.BuildingNumber = request.BuildingNumber;
            if (request.ApartmentNumber is not null)
            {
                orderAddress.ApartmentNumber = request.ApartmentNumber;
            }
            orderAddress.ZipCode = request.ZipCode;
            orderAddress.District = request.District;
            orderAddress.City = request.City;

            _orderAddressRepository.Update(orderAddress);
            await _orderAddressRepository.Commit();
            return _mapper.Map<OrderAddressDTO>(orderAddress);
        }

        public async Task<OrderAddressDTO> Handle(DeletedOrderAddressCommand request, CancellationToken cancellationToken)
        {
            var orderAddress = await _orderAddressRepository.GetById(request.Id);
            if (orderAddress is null)
            {
                throw new NotImplementedException();
            }

            await _orderAddressRepository.Delete(orderAddress);
            await _orderAddressRepository.Commit();

            return _mapper.Map<OrderAddressDTO>(orderAddress);
        }
    }
}