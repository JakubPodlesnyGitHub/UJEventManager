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
            CreateMap<ShopOrder, ShopOrderDTO>();
            CreateMap<ShopOrderDTO, ShopOrder>();
            CreateMap<AddedShopOrderCommand, ShopOrder>();
            CreateMap<EditedShopOrderCommand, ShopOrder>();
        }
    }
}