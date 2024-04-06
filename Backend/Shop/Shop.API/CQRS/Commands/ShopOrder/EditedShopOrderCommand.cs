using Shop.Domain.Enums;

namespace Shop.API.CQRS.Commands.ShopOrder
{
    public class EditedShopOrderCommand : ICommandBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OrderCode { get; set; }
        public DateTime ExpectedLeadTime { get; set; }
        public double Total { get; set; }
        public OrderSatatus Status { get; set; }

        public EditedShopOrderCommand(Guid id, string name, string orderCode, DateTime expectedLeadTime, double total, OrderSatatus status)
        {
            Id = id;
            Name = name;
            OrderCode = orderCode;
            ExpectedLeadTime = expectedLeadTime;
            Total = total;
            Status = status;
        }
    }
}