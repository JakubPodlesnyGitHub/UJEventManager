namespace Shop.API.CQRS.Queries.Payment
{
    public class GetPaymentByIdQuery : IQueryBase
    {
        public Guid Id { get; set; }

        public GetPaymentByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}