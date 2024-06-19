using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Queries.Product
{
    public class GetSortedProductsQuery : IRequest<IList<ProductDTO>>
    {
        public string PropertyName { get; set; }
        public string Order { get; set; }

        public GetSortedProductsQuery(string propertyName, string order)
        {
            PropertyName = propertyName;
            Order = order;
        }
    }
}
