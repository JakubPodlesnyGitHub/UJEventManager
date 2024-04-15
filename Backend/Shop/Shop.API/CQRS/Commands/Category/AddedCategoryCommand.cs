using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Commands.Category
{
    public class AddedCategoryCommand : IRequest<CategoryDTO>
    {
        public string Name { get; set; }

        public AddedCategoryCommand(string name)
        {
            Name = name;
        }
    }
}