namespace Shop.API.CQRS.Queries.User
{
    public class GetUserByEmailQuery : IQueryBase
    {
        public string Email { get; set; }

        public GetUserByEmailQuery(string email)
        {
            Email = email;
        }
    }
}