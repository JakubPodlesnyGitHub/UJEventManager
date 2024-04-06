namespace Shop.API.CQRS.Commands.Category
{
    public class DeletedCategoryCommand : ICommandBase
    {
        public Guid Id { get; set; }

        public DeletedCategoryCommand(Guid id)
        {
            Id = id;
        }
    }
}