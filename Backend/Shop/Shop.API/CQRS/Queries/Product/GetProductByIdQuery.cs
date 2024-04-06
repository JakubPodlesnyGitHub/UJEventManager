namespace Shop.API.CQRS.Queries.Product
{
    public class GetProductByIdQuery : IQueryBase
    {
        public Guid Id { get; set; }

        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}