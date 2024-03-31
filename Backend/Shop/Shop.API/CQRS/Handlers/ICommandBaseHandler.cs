using Shop.API.CQRS.Commands;

namespace Shop.API.CQRS.Handlers
{
    public interface ICommandBaseHandler<in TCommand, TResponse> where TCommand : ICommandBase
    {
        Task<TResponse> HandleAsync(TCommand command);
    }
}