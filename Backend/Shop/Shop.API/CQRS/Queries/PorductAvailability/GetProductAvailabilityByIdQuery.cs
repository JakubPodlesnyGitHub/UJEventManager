namespace Shop.API.CQRS.Queries.PorductAvailability
{
    public class GetProductAvailabilityByIdQuery : IQueryBase
    {
        public Guid Id { get; set; }

        public GetProductAvailabilityByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}