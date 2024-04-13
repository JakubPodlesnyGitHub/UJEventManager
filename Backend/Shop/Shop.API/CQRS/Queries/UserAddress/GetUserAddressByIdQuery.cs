using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Queries.UserAddress
{
    public class GetUserAddressByIdQuery : IRequest<UserAddressDTO>
    {
        public Guid Id { get; set; }

        public GetUserAddressByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}