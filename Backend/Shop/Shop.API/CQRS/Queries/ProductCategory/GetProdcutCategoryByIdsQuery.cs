namespace Shop.API.CQRS.Queries.ProductCategory
{
    public class GetProdcutCategoryByIdsQuery : IQueryBase
    {
        public Guid Id { get; set; }

        public GetProdcutCategoryByIdsQuery(Guid id)
        {
            Id = id;
        }
    }
}