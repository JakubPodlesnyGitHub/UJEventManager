namespace Shop.API.CQRS.Commands.Category
{
    public class AddedCategoryCommand : ICommandBase
    {
        public string Name { get; set; }

        public AddedCategoryCommand(string name)
        {
            Name = name;
        }
    }
}