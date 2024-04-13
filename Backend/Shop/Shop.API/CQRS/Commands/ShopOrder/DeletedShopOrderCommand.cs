using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Commands.ShopOrder
{
    public class DeletedShopOrderCommand : IRequest<ShopOrderDTO>
    {
        public Guid Id { get; set; }

        public DeletedShopOrderCommand(Guid id)
        {
            Id = id;
        }
    }
}