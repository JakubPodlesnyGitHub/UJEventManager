using AutoMapper;
using Shop.API.CQRS.Commands.User;
using Shop.Domain.Domain;
using Shop.Shared.Dtos.Response;

namespace Shop.API.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>()
                .ForPath(d => d.Payments, o => o.MapFrom(s => s.PaymentsNavigation))
                .ForPath(d => d.ShopOrders, o => o.MapFrom(s => s.ShopOrdersNavigation))
                .ForPath(d => d.UserAddresses, o => o.MapFrom(s => s.UserAddressesNavigation));
            CreateMap<UserDTO, User>();
            CreateMap<AddedUserCommand, User>();
            CreateMap<EditedUserCommand, User>();
        }
    }
}