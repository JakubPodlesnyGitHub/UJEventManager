namespace Shop.API.CQRS.Commands.OrderItem
{
    public class DeletedOrderItemCommand : ICommandBase
    {
        public Guid Id { get; set; }

        public DeletedOrderItemCommand(Guid id)
        {
            Id = id;
        }
    }
}