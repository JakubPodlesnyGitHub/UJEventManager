using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Queries.OrderAddress
{
    public class GetOrderAddressByIdQuery : IRequest<OrderAddressDTO>
    {
        public Guid Id { get; set; }

        public GetOrderAddressByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}