using AutoMapper;
using Shop.API.CQRS.Commands.User;
using Shop.API.CQRS.Handlers.Interfaces;
using Shop.API.CQRS.Queries.User;
using Shop.Domain.Domain;
using Shop.Infrastructure.Repositories.Interfaces;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Handlers
{
    public class UserHandler :
        IQueryBaseHandler<GetUsersQuery, IList<UserDTO>>,
        IQueryBaseHandler<GetUserByIdQuery, UserDTO>,
        IQueryBaseHandler<GetUserByEmailQuery, UserDTO>,
        ICommandBaseHandler<AddedUserCommand, UserDTO>,
        ICommandBaseHandler<EditedUserCommand, UserDTO>,
        ICommandBaseHandler<DeletedUserCommand, UserDTO>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDTO> HandleAsync(GetUserByIdQuery command)
        {
            var user = await _userRepository.GetById(command.Id);
            if (user is null)
            {
                throw new NotImplementedException();
            }
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<IList<UserDTO>> HandleAsync(GetUsersQuery command)
        {
            var users = await _userRepository.GetAll();
            return _mapper.Map<IList<UserDTO>>(users);
        }

        public async Task<UserDTO> HandleAsync(GetUserByEmailQuery command)
        {
            var user = await _userRepository.GetBy(x => x.Email == command.Email);
            if (user is null)
            {
                throw new NotImplementedException();
            }
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> HandleAsync(AddedUserCommand command)
        {
            var user = _userRepository.Insert(_mapper.Map<User>(command));
            await _userRepository.Commit();
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> HandleAsync(EditedUserCommand command)
        {
            var user = await _userRepository.GetById(command.Id);
            if (user is null)
            {
                throw new NotImplementedException();
            }

            user.FirstName = command.FirstName;
            user.LastName = command.LastName;
            user.BirthDate = command.BirthDate;
            user.PhoneNumber = command.Phone;
            if (command.Picture is not null)
            {
                user.Picture = command.Picture;
            }

            _userRepository.Update(user);
            await _userRepository.Commit();
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> HandleAsync(DeletedUserCommand command)
        {
            var user = await _userRepository.GetById(command.Id);
            if (user is null)
            {
                throw new NotImplementedException();
            }
            await _userRepository.Delete(user);
            await _userRepository.Commit();

            return _mapper.Map<UserDTO>(user);
        }
    }
}