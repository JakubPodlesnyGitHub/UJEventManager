using AutoMapper;
using Shop.API.CQRS.Commands.ShopOrder;
using Shop.Domain.Domain;
using Shop.Shared.Dtos.Response;

namespace Shop.API.Mappings
{
    public class ShopOrderProfile : Profile
    {
        public ShopOrderProfile()
        {
            CreateMap<ShopOrder, ShopOrderDTO>()
                .ForPath(d => d.OrderAddress, o => o.MapFrom(s => s.OrderAddressNavigation))
                .ForPath(d => d.OrderItems, o => o.MapFrom(s => s.OrderItemsNavigation))
                .ForPath(d => d.Payment, o => o.MapFrom(s => s.PaymentNavigation))
                .ForPath(d => d.User, o => o.MapFrom(s => s.UserNavigation));
            CreateMap<ShopOrderDTO, ShopOrder>();
            CreateMap<AddedShopOrderCommand, ShopOrder>();
            CreateMap<EditedShopOrderCommand, ShopOrder>();
        }
    }
}