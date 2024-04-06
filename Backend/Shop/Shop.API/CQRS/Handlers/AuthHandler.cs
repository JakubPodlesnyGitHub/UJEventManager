using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Shop.API.CQRS.Commands.Auth;
using Shop.API.CQRS.Handlers.Interfaces;
using Shop.Domain.Domain;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Handlers
{
    public class AuthHandler :
        ICommandBaseHandler<UserLoginCommand, AuthDTO>,
        ICommandBaseHandler<UserRegisterCommand, AuthDTO>,
        ICommandBaseHandler<UserPasswordChangedCommand, AuthDTO>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public AuthHandler(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<AuthDTO> HandleAsync(UserLoginCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<AuthDTO> HandleAsync(UserRegisterCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<AuthDTO> HandleAsync(UserPasswordChangedCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
