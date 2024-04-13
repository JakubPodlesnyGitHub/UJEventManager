using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Commands.Category
{
    public class EditedCategoryCommand : IRequest<CategoryDTO>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public EditedCategoryCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}