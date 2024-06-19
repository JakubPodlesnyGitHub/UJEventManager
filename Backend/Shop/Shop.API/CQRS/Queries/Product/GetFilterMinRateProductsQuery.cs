using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Queries.Product
{
    public class GetFilterMinRateProductsQuery : IRequest<IList<ProductDTO>>
    {
        public double Min { get; set; }

        public GetFilterMinRateProductsQuery(double min)
        {
            Min = min;
        }
    }
}
