using AutoMapper;
using MediatR;
using Shop.API.CQRS.Commands.UserAddress;
using Shop.API.CQRS.Queries.UserAddress;
using Shop.Domain.Domain;
using Shop.Infrastructure.Repositories.Interfaces;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Handlers
{
    public class UserAddressHandler :
        IRequestHandler<GetUserAddressesQuery, IList<UserAddressDTO>>,
        IRequestHandler<GetUserAddressByIdQuery, UserAddressDTO>,
        IRequestHandler<AddedUserAddressCommand, UserAddressDTO>,
        IRequestHandler<EdditedUserAdressCommand, UserAddressDTO>,
        IRequestHandler<DeletedUserAdressCommand, UserAddressDTO>
    {
        private readonly IMapper _mapper;
        private readonly IUserAddressRepository _userAddressRepository;

        public UserAddressHandler(IMapper mapper, IUserAddressRepository userAddressRepository)
        {
            _mapper = mapper;
            _userAddressRepository = userAddressRepository;
        }

        public async Task<IList<UserAddressDTO>> Handle(GetUserAddressesQuery request, CancellationToken cancellationToken)
        {
            var userAddresses = await _userAddressRepository.GetUserAddressesWithUsers();
            return _mapper.Map<IList<UserAddressDTO>>(userAddresses);
        }

        public async Task<UserAddressDTO> Handle(GetUserAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var userAddress = await _userAddressRepository.GetUserAddressByIdWithUser(request.Id);
            if (userAddress is null)
            {
                throw new NotImplementedException();
            }
            return _mapper.Map<UserAddressDTO>(userAddress);
        }

        public async Task<UserAddressDTO> Handle(AddedUserAddressCommand request, CancellationToken cancellationToken)
        {
            var userAddress = _userAddressRepository.Insert(_mapper.Map<UserAddress>(request));
            await _userAddressRepository.Commit();
            return _mapper.Map<UserAddressDTO>(userAddress);
        }

        public async Task<UserAddressDTO> Handle(EdditedUserAdressCommand request, CancellationToken cancellationToken)
        {
            var userAddress = await _userAddressRepository.GetById(request.Id);
            if (userAddress is null)
            {
                throw new NotImplementedException();
            }

            userAddress.StreetName = request.StreetName;
            userAddress.BuildingNumber = request.BuildingNumber;
            if (request.ApartmentNumber is not null)
            {
                userAddress.ApartmentNumber = request.ApartmentNumber;
            }
            userAddress.ZipCode = request.ZipCode;
            userAddress.District = request.District;
            userAddress.City = request.City;

            _userAddressRepository.Update(userAddress);
            await _userAddressRepository.Commit();
            return _mapper.Map<UserAddressDTO>(userAddress);
        }

        public async Task<UserAddressDTO> Handle(DeletedUserAdressCommand request, CancellationToken cancellationToken)
        {
            var userAddress = await _userAddressRepository.GetById(request.Id);
            if (userAddress is null)
            {
                throw new NotImplementedException();
            }
            await _userAddressRepository.Delete(userAddress.Id);
            await _userAddressRepository.Commit();

            return _mapper.Map<UserAddressDTO>(userAddress);
        }
    }
}