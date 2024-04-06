using AutoMapper;
using Shop.API.CQRS.Commands.ShopOrder;
using Shop.Domain.Domain;
using Shop.Shared.Dtos.Response;

namespace Shop.API.Mappings
{
    public class UserAddressProfile : Profile
    {
        public UserAddressProfile()
        {
            CreateMap<UserAddressDTO, UserAddress>()
                 .ForPath(x => x.UserNavigation, o => o.MapFrom(o => o.User));
            CreateMap<UserAddress, UserAddressDTO>()
                .ForPath(x => x.User, o => o.MapFrom(o => o.UserNavigation));
            CreateMap<AddedShopOrderCommand, ShopOrder>();
            CreateMap<EditedShopOrderCommand, ShopOrder>();
        }
    }
}