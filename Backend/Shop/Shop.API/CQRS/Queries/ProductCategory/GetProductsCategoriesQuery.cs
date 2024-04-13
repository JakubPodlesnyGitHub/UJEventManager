using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Queries.ProductCategory
{
    public class GetProductsCategoriesQuery : IRequest<IList<ProductCategoryDTO>>
    {
    }
}