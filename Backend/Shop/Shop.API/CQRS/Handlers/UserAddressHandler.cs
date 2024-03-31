using Shop.API.CQRS.Commands.UserAddress;
using Shop.API.CQRS.Queries.UserAddress;
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
        public Task<IList<UserAddressDTO>> HandleAsync(GetUserAddressesQuery command)
        {
            throw new NotImplementedException();
        }

        public Task<UserAddressDTO> HandleAsync(GetUserAddressByIdQuery command)
        {
            throw new NotImplementedException();
        }

        public Task<UserAddressDTO> HandleAsync(AddedUserAddressCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<UserAddressDTO> HandleAsync(EdditedUserAdressCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<UserAddressDTO> HandleAsync(DeletedUserAdressCommand command)
        {
            throw new NotImplementedException();
        }
    }
}