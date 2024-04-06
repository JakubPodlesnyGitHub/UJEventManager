using AutoMapper;
using Shop.Domain.Domain;
using Shop.Shared.Dtos.Response;

namespace Shop.API.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}