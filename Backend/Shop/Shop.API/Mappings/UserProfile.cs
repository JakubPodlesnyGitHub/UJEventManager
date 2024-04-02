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
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<AddedUserCommand, User>();
            CreateMap<EditedUserCommand, User>();
        }
    }
}