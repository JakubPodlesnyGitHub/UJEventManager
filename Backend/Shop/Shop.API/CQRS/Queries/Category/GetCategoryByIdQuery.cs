namespace Shop.API.CQRS.Queries.Category
{
    public class GetCategoryByIdQuery : IQueryBase
    {
        public Guid Id { get; set; }

        public GetCategoryByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}