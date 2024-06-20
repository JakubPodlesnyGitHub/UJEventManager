using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Queries.Product
{
    public class GetSortedProductsQuery : IRequest<IList<ProductDTO>>
    {
        public string PropertyName { get; set; }
        public string Order { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }

        public GetSortedProductsQuery(string propertyName, string order, double min, double max)
        {
            PropertyName = propertyName;
            Order = order;
            Min = min;
            Max = max;
        }
    }
}
