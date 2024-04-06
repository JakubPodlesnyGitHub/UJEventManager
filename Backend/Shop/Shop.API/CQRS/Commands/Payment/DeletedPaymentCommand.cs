namespace Shop.API.CQRS.Commands.Payment
{
    public class DeletedPaymentCommand : ICommandBase
    {
        public Guid Id { get; set; }

        public DeletedPaymentCommand(Guid id)
        {
            Id = id;
        }
    }
}