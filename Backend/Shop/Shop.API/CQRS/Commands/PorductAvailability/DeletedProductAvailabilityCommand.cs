namespace Shop.API.CQRS.Commands.PorductAvailability
{
    public class DeletedProductAvailabilityCommand : ICommandBase
    {
        public Guid Id { get; set; }

        public DeletedProductAvailabilityCommand(Guid id)
        {
            Id = id;
        }
    }
}