using MediatR;
using Shop.Domain.Enums;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Commands.ShopOrder
{
    public class AddedShopOrderCommand : IRequest<ShopOrderDTO>
    {
        public string Name { get; set; }
        public string OrderCode { get; set; }
        public DateTime ExpectedLeadTime { get; set; }
        public double Total { get; set; }
        public OrderSatatus Status { get; set; }
        public Guid IdOrderAddress { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdPayment { get; set; }

        public AddedShopOrderCommand(string name, string orderCode, DateTime expectedLeadTime, double total, OrderSatatus status, Guid idOrderAddress, Guid idUser, Guid idPayment)
        {
            Name = name;
            OrderCode = orderCode;
            ExpectedLeadTime = expectedLeadTime;
            Total = total;
            Status = status;
            IdOrderAddress = idOrderAddress;
            IdUser = idUser;
            IdPayment = idPayment;
        }
    }
}