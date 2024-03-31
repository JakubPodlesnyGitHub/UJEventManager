using Shop.API.CQRS.Queries;

namespace Shop.API.CQRS.Handlers
{
    public interface IQueryBaseHandler<in TQuery, TResponse> where TQuery : IQueryBase
    {
        Task<TResponse> HandleAsync(TQuery command);
    }
}