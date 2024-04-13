using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Queries.ShopOrder
{
    public class GetShopOrderByIdQuery : IRequest<ShopOrderDTO>
    {
        public Guid Id { get; set; }

        public GetShopOrderByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}