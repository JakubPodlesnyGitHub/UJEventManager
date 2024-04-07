namespace Shop.API.CQRS.Queries.User
{
    public class GetUserByIdQuery : IQueryBase
    {
        public Guid Id { get; set; }

        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}