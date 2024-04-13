using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Queries.Category
{
    public class GetCategoriesQuery : IRequest<IList<CategoryDTO>>
    {
    }
}