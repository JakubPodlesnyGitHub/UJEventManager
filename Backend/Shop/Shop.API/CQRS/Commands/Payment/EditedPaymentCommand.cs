﻿namespace Shop.API.CQRS.Commands.Payment
{
    public class EditedPaymentCommand : ICommandBase
    {
        public Guid Id { get; set; }
        public string PaymentMethod { get; set; }
        public string Data { get; set; }
        public double Amount { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdShopOrder { get; set; }

        public EditedPaymentCommand(Guid id, string paymentMethod, string data, double amount, DateTime creationDate, Guid idUser, Guid idShopOrder)
        {
            Id = id;
            PaymentMethod = paymentMethod;
            Data = data;
            Amount = amount;
            CreationDate = creationDate;
            IdUser = idUser;
            IdShopOrder = idShopOrder;
        }
    }
}