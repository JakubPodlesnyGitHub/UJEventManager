namespace Shop.API.CQRS.Commands.PorductAvailability
{
    public class EditedProductAvailabilityCommand : ICommandBase
    {
        public Guid Id { get; set; }
        public int Availability { get; set; }
        public string Status { get; set; }
        public Guid IdProduct { get; set; }

        public EditedProductAvailabilityCommand(Guid id, int availability, string status, Guid idProduct)
        {
            Id = id;
            Availability = availability;
            Status = status;
            IdProduct = idProduct;
        }
    }
}