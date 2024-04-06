namespace Shop.API.CQRS.Commands.OrderAddress
{
    public class DeletedOrderAddressCommand : ICommandBase
    {
        public Guid Id { get; set; }

        public DeletedOrderAddressCommand(Guid id)
        {
            Id = id;
        }
    }
}