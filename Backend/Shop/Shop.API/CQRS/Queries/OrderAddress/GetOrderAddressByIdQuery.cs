namespace Shop.API.CQRS.Queries.OrderAddress
{
    public class GetOrderAddressByIdQuery : IQueryBase
    {
        public Guid Id { get; set; }

        public GetOrderAddressByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}