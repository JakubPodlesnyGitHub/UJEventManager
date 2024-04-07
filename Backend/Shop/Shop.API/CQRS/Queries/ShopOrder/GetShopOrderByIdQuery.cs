namespace Shop.API.CQRS.Queries.ShopOrder
{
    public class GetShopOrderByIdQuery : IQueryBase
    {
        public Guid Id { get; set; }

        public GetShopOrderByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}