using AutoMapper;
using Shop.API.CQRS.Commands.OrderAddress;
using Shop.API.CQRS.Handlers.Interfaces;
using Shop.API.CQRS.Queries.OrderAddress;
using Shop.Domain.Domain;
using Shop.Infrastructure.Repositories.Interfaces;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Handlers
{
    public class OrderAddressHandler :
        IQueryBaseHandler<GetOrderAdderssesQuery, IList<OrderAddressDTO>>,
        IQueryBaseHandler<GetOrderAddressByIdQuery, OrderAddressDTO>,
        ICommandBaseHandler<AddedOrderAddressCommand, OrderAddressDTO>,
        ICommandBaseHandler<EditedOrderAddressCommand, OrderAddressDTO>,
        ICommandBaseHandler<DeletedOrderAddressCommand, OrderAddressDTO>
    {
        private readonly IOrderAddressRepository _orderAddressRepository;
        private readonly IMapper _mapper;

        public async Task<IList<OrderAddressDTO>> HandleAsync(GetOrderAdderssesQuery command)
        {
            return _mapper.Map<IList<OrderAddressDTO>>(await _orderAddressRepository.GetAll());
        }

        public async Task<OrderAddressDTO> HandleAsync(GetOrderAddressByIdQuery command)
        {
            var searchOrderAddress = await _orderAddressRepository.GetById(command.Id);
            if (searchOrderAddress is null)
            {
                throw new NotImplementedException();
            }
            return _mapper.Map<OrderAddressDTO>(searchOrderAddress);
        }

        public async Task<OrderAddressDTO> HandleAsync(AddedOrderAddressCommand command)
        {
            _orderAddressRepository.Insert(_mapper.Map<OrderAddress>(command));
            await _orderAddressRepository.Commit();
            return _mapper.Map<OrderAddressDTO>(command);
        }

        public async Task<OrderAddressDTO> HandleAsync(EditedOrderAddressCommand command)
        {
            var orderAddress = await _orderAddressRepository.GetById(command.Id);
            if (orderAddress is null)
            {
                throw new NotImplementedException();
            }

            orderAddress.StreetName = command.StreetName;
            orderAddress.BuildingNumber = command.BuildingNumber;
            if (command.ApartmentNumber is not null)
            {
                orderAddress.ApartmentNumber = command.ApartmentNumber;
            }
            orderAddress.ZipCode = command.ZipCode;
            orderAddress.District = command.District;
            orderAddress.City = command.City;

            _orderAddressRepository.Update(orderAddress);
            await _orderAddressRepository.Commit();
            return _mapper.Map<OrderAddressDTO>(orderAddress);
        }

        public async Task<OrderAddressDTO> HandleAsync(DeletedOrderAddressCommand command)
        {
            var orderAddress = await _orderAddressRepository.GetById(command.Id);
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