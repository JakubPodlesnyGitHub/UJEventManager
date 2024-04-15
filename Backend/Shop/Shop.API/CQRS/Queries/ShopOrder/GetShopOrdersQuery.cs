using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Queries.ShopOrder
{
    public class GetShopOrdersQuery : IRequest<IList<ShopOrderDTO>>
    {
    }
}