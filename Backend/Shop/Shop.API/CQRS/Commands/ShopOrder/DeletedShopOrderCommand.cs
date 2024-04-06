namespace Shop.API.CQRS.Commands.ShopOrder
{
    public class DeletedShopOrderCommand : ICommandBase
    {
        public Guid Id { get; set; }

        public DeletedShopOrderCommand(Guid id)
        {
            Id = id;
        }
    }
}