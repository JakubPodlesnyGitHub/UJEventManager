using AutoMapper;
using Shop.API.CQRS.Commands.Payment;
using Shop.Domain.Domain;
using Shop.Shared.Dtos.Response;

namespace Shop.API.Mappings
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<Payment, PaymentDTO>();
            CreateMap<PaymentDTO, Payment>();
            CreateMap<AddedPaymentCommand, Payment>();
            CreateMap<EditedPaymentCommand, Payment>();
        }
    }
}