using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Queries.Product
{
    public class GetSortedProductsQuery : IRequest<IList<ProductDTO>>
    {
        public int Sorted { get; set; }
        public string PropertyName { get; set; }
        public List<FilterCriterion> Filters { get; set; } = new List<FilterCriterion>();

        public GetSortedProductsQuery(int sorted, string propertyName, List<FilterCriterion> filterCriteria )
        {
            this.Sorted = sorted;
            this.PropertyName = propertyName;
            this.Filters = filterCriteria;
        }
    }

    public class FilterCriterion
    {
        public string PropertyName { get; set; }
        public object MinValue { get; set; }
        public object MaxValue { get; set; }

        public object ExactValue { get; set; }
    }
}
