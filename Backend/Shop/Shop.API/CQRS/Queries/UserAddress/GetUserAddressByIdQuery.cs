namespace Shop.API.CQRS.Queries.UserAddress
{
    public class GetUserAddressByIdQuery : IQueryBase
    {
        public Guid Id { get; set; }

        public GetUserAddressByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}