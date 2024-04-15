using AutoMapper;
using Shop.API.CQRS.Commands.Auth;
using Shop.Domain.Domain;
using Shop.Shared.Dtos.Response;

namespace Shop.API.Mappings
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<UserRegisterCommand, User>();
            CreateMap<UserLoginCommand, User>();
        }
    }
}
