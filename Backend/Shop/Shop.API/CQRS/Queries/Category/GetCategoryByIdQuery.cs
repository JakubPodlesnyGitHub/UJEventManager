using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Queries.Category
{
    public class GetCategoryByIdQuery : IRequest<CategoryDTO>
    {
        public Guid Id { get; set; }

        public GetCategoryByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}