using AutoMapper;
using Shop.API.CQRS.Commands.UserAddress;
using Shop.API.CQRS.Handlers.Interfaces;
using Shop.API.CQRS.Queries.UserAddress;
using Shop.Domain.Domain;
using Shop.Infrastructure.Repositories.Interfaces;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Handlers
{
    public class UserAddressHandler :
        IQueryBaseHandler<GetUserAddressesQuery, IList<UserAddressDTO>>,
        IQueryBaseHandler<GetUserAddressByIdQuery, UserAddressDTO>,
        ICommandBaseHandler<AddedUserAddressCommand, UserAddressDTO>,
        ICommandBaseHandler<EdditedUserAdressCommand, UserAddressDTO>,
        ICommandBaseHandler<DeletedUserAdressCommand, UserAddressDTO>
    {
        private readonly IMapper _mapper;
        private readonly IUserAddressRepository _userAddressRepository;

        public UserAddressHandler(IMapper mapper, IUserAddressRepository userAddressRepository)
        {
            _mapper = mapper;
            _userAddressRepository = userAddressRepository;
        }

        public async Task<IList<UserAddressDTO>> HandleAsync(GetUserAddressesQuery command)
        {
            var userAddresses = await _userAddressRepository.GetUserAddressesWithUsers();
            return _mapper.Map<IList<UserAddressDTO>>(userAddresses);
        }

        public async Task<UserAddressDTO> HandleAsync(GetUserAddressByIdQuery command)
        {
            var userAddress = await _userAddressRepository.GetUserAddressByIdWithUser(command.Id);
            if (userAddress is null)
            {
                throw new NotImplementedException();
            }
            return _mapper.Map<UserAddressDTO>(userAddress);
        }

        public async Task<UserAddressDTO> HandleAsync(AddedUserAddressCommand command)
        {
            var userAddress = _userAddressRepository.Insert(_mapper.Map<UserAddress>(command));
            await _userAddressRepository.Commit();
            return _mapper.Map<UserAddressDTO>(userAddress);
        }

        public async Task<UserAddressDTO> HandleAsync(EdditedUserAdressCommand command)
        {
            var userAddress = await _userAddressRepository.GetById(command.Id);
            if (userAddress is null)
            {
                throw new NotImplementedException();
            }

            userAddress.StreetName = command.StreetName;
            userAddress.BuildingNumber = command.BuildingNumber;
            if (command.ApartmentNumber is not null)
            {
                userAddress.ApartmentNumber = command.ApartmentNumber;
            }
            userAddress.ZipCode = command.ZipCode;
            userAddress.District = command.District;
            userAddress.City = command.City;

            _userAddressRepository.Update(userAddress);
            await _userAddressRepository.Commit();
            return _mapper.Map<UserAddressDTO>(userAddress);
        }

        public async Task<UserAddressDTO> HandleAsync(DeletedUserAdressCommand command)
        {
            var userAddress = await _userAddressRepository.GetById(command.Id);
            if (userAddress is null)
            {
                throw new NotImplementedException();
            }
            await _userAddressRepository.Delete(userAddress);
            await _userAddressRepository.Commit();

            return _mapper.Map<UserAddressDTO>(userAddress);
        }
    }
}