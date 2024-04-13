using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Commands.Category
{
    public class DeletedCategoryCommand : IRequest<CategoryDTO>
    {
        public Guid Id { get; set; }

        public DeletedCategoryCommand(Guid id)
        {
            Id = id;
        }
    }
}