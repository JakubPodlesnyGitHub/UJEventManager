namespace Shop.API.CQRS.Commands.Product
{
    public class DeletedProductCommand : ICommandBase
    {
        public Guid Id { get; set; }

        public DeletedProductCommand(Guid id)
        {
            Id = id;
        }
    }
}