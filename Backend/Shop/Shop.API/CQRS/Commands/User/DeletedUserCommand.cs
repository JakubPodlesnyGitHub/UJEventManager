namespace Shop.API.CQRS.Commands.User
{
    public class DeletedUserCommand : ICommandBase
    {
        public Guid Id { get; set; }

        public DeletedUserCommand(Guid id)
        {
            Id = id;
        }
    }
}