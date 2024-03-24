using Shop.API.CQRS.Commands;
using Shop.API.CQRS.Queries;

namespace Shop.API.CQRS.Handlers
{
    public interface IQueryBaseHandler<in TQuery> where TQuery : IQueryBase
    {
        Task HandleAsync(TQuery command);
    }
}
