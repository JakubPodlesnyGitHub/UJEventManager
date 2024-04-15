using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Queries.Product
{
    public class GetProductsQuery : IRequest<IList<ProductDTO>>
    {
    }
}