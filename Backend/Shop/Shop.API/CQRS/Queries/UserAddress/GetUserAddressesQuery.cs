using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Queries.UserAddress
{
    public class GetUserAddressesQuery : IRequest<IList<UserAddressDTO>>
    {
    }
}