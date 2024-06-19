using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Queries.Product
{
    public class GetFilterMaxRateProductsQuery : IRequest<IList<ProductDTO>>
    {

        public double Max { get; set; }

        public GetFilterMaxRateProductsQuery(double max)
        {
            Max = max;
        }
    }
}
