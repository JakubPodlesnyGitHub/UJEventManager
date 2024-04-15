using AutoMapper;
using Shop.API.CQRS.Commands.ShopOrder;
using Shop.API.CQRS.Commands.UserAddress;
using Shop.Domain.Domain;
using Shop.Shared.Dtos.Response;

namespace Shop.API.Mappings
{
    public class UserAddressProfile : Profile
    {
        public UserAddressProfile()
        {
            CreateMap<UserAddressDTO, UserAddress>();
            CreateMap<UserAddress, UserAddressDTO>()
                .ForPath(x => x.User, o => o.MapFrom(o => o.UserNavigation));
            CreateMap<AddedUserAddressCommand, ShopOrder>();
            CreateMap<EdditedUserAdressCommand, ShopOrder>();
        }
    }
}