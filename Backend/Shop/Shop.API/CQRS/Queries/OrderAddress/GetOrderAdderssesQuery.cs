using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Queries.OrderAddress
{
    public class GetOrderAdderssesQuery : IRequest<IList<OrderAddressDTO>>
    {
    }
}