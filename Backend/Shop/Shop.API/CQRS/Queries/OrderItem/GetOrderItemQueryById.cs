namespace Shop.API.CQRS.Queries.OrderItem
{
    public class GetOrderItemQueryById : IQueryBase
    {
        public Guid Id { get; set; }

        public GetOrderItemQueryById(Guid id)
        {
            Id = id;
        }
    }
}