using AutoMapper;
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
        }
    }
}