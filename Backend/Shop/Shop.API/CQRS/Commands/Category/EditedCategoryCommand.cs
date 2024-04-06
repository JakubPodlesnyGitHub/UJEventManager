namespace Shop.API.CQRS.Commands.Category
{
    public class EditedCategoryCommand : ICommandBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}