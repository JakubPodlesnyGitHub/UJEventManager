using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Commands.Payment
{
    public class AddedPaymentCommand : IRequest<PaymentDTO>
    {
        public string PaymentMethod { get; set; }
        public string Data { get; set; }
        public double Amount { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdShopOrder { get; set; }

        public AddedPaymentCommand(string paymentMethod, string data, double amount, Guid idUser, Guid idShopOrder)
        {
            PaymentMethod = paymentMethod;
            Data = data;
            Amount = amount;
            IdUser = idUser;
            IdShopOrder = idShopOrder;
        }
    }
}