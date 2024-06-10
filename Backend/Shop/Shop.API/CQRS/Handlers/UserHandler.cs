using AutoMapper;
using MediatR;
using Shop.API.CQRS.Commands.User;
using Shop.API.CQRS.Queries.User;
using Shop.Domain.Domain;
using Shop.Infrastructure.Repositories.Interfaces;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Handlers
{
    public class UserHandler :
        IRequestHandler<GetUsersQuery, IList<UserDTO>>,
        IRequestHandler<GetUserByIdQuery, UserDTO>,
        IRequestHandler<GetUserByEmailQuery, UserDTO>,
        IRequestHandler<AddedUserCommand, UserDTO>,
        IRequestHandler<EditedUserCommand, UserDTO>,
        IRequestHandler<DeletedUserCommand, UserDTO>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<IList<UserDTO>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetUsersWithPaymentsAndUserAddressesAndShopOrdrders();
            return _mapper.Map<IList<UserDTO>>(users);
        }

        public async Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdWithPaymentsAndUserAddressesAndShopOrdrders(request.Id);
            if (user is null)
            {
                throw new NotImplementedException();
            }
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailWithPaymentsAndUserAddressesAndShopOrdrders(request.Email);
            if (user is null)
            {
                throw new NotImplementedException();
            }
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> Handle(AddedUserCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.Insert(_mapper.Map<User>(request));
            await _userRepository.Commit();
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> Handle(EditedUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.Id);
            if (user is null)
            {
                throw new NotImplementedException();
            }

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.BirthDate = request.BirthDate;
            user.PhoneNumber = request.Phone;
            if (request.Picture is not null)
            {
                user.Picture = request.Picture;
            }

            _userRepository.Update(user);
            await _userRepository.Commit();
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> Handle(DeletedUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.Id);
            if (user is null)
            {
                throw new NotImplementedException();
            }
            await _userRepository.Delete(user.Id);
            await _userRepository.Commit();

            return _mapper.Map<UserDTO>(user);
        }
    }
}