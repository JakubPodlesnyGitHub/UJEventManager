namespace Shop.API.CQRS.Commands.UserAddress
{
    public class DeletedUserAdressCommand : ICommandBase
    {
        public Guid Id { get; set; }

        public DeletedUserAdressCommand(Guid id)
        {
            Id = id;
        }
    }
}