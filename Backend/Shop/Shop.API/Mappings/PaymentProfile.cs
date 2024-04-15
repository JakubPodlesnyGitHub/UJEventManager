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
            CreateMap<Payment, PaymentDTO>()
                .ForPath(d => d.ShopOrders, o => o.MapFrom(s => s.ShopOrdersNavigation))
                .ForPath(d => d.User, o => o.MapFrom(s => s.UserNavigation));
            CreateMap<PaymentDTO, Payment>();
            CreateMap<AddedPaymentCommand, Payment>();
            CreateMap<EditedPaymentCommand, Payment>();
        }
    }
}