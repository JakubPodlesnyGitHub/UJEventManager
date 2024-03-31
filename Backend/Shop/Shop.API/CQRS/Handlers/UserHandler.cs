using Shop.API.CQRS.Commands.UserAddress;
using Shop.API.CQRS.Queries.User;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Handlers
{
    public class UserHandler :
        IQueryBaseHandler<GetUsersQuery, IList<UserDTO>>,
        IQueryBaseHandler<GetUserByIdQuery, UserDTO>,
        IQueryBaseHandler<GetUserByEmailQuery, UserDTO>,
        ICommandBaseHandler<AddedUserAddressCommand, UserDTO>,
        ICommandBaseHandler<EdditedUserAdressCommand, UserDTO>,
        ICommandBaseHandler<DeletedUserAdressCommand, UserDTO>
    {
        public Task<UserDTO> HandleAsync(GetUserByIdQuery command)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserDTO>> HandleAsync(GetUsersQuery command)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> HandleAsync(GetUserByEmailQuery command)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> HandleAsync(AddedUserAddressCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> HandleAsync(EdditedUserAdressCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> HandleAsync(DeletedUserAdressCommand command)
        {
            throw new NotImplementedException();
        }
    }
}