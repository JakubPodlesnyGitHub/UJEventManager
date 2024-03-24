using Shop.API.CQRS.Commands;

namespace Shop.API.CQRS.Handlers
{
    public interface ICommandBaseHandler<in TCommand> where TCommand: ICommandBase
    {
        Task HandleAsync(TCommand command);
    }
}
