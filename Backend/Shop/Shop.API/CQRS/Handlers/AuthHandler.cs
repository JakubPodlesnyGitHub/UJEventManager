using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shop.API.CQRS.Commands.Auth;
using Shop.Domain.Domain;
using Shop.Domain.Enums;
using Shop.Infrastructure.Services.Interfaces;
using Shop.Shared.Dtos.Response;
using System.IdentityModel.Tokens.Jwt;

namespace Shop.API.CQRS.Handlers
{
    public class AuthHandler :
        IRequestHandler<UserLoginCommand, AuthDTO>,
        IRequestHandler<UserRegisterCommand, AuthDTO>,
        IRequestHandler<UserPasswordChangedCommand, AuthDTO>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;

        public AuthHandler(IMapper mapper, UserManager<User> userManager, ITokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<AuthDTO> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                throw new UnauthorizedAccessException("Invalid Authentication - Incorect email or password");
            }

            var credentails = _tokenService.GetSigningCredentials();
            var userClaims = await _tokenService.GetClaims(user);
            var tokenSettgins = _tokenService.GenerateTokenSettings(credentails, userClaims);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenSettgins);

            user.RefreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(5);

            await _userManager.UpdateAsync(user);

            return new AuthDTO { IsAuthenticated = true, IsSucceded = true, Token = token, RefreshToken = user.RefreshToken };
        }

        public async Task<AuthDTO> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            var newUser = _mapper.Map<User>(request);
            IdentityResult result = await _userManager.CreateAsync(newUser, request.Password);

            if (!result.Succeeded)
            {
                return new AuthDTO { IsSucceded = false, ErrorDetails = "Registration doesn't succeded" };
            }

            if (request.IsAdmin)
            {
                await _userManager.AddToRoleAsync(newUser, UserRole.ADMIN.ToString());
            }
            else
            {
                await _userManager.AddToRoleAsync(newUser, UserRole.SYSTEM_CLIENT.ToString());
            }

            var credentails = _tokenService.GetSigningCredentials();
            var userClaims = await _tokenService.GetClaims(newUser);
            var tokenSettgins = _tokenService.GenerateTokenSettings(credentails, userClaims);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenSettgins);

            newUser.RefreshToken = _tokenService.GenerateRefreshToken();
            newUser.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(5);

            await _userManager.UpdateAsync(newUser);

            return new AuthDTO { IsAuthenticated = true, IsSucceded = true, Token = token, RefreshToken = newUser.RefreshToken };
        }

        public async Task<AuthDTO> Handle(UserPasswordChangedCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user is null)
            {
                throw new NotImplementedException();
            }
            if (await _userManager.CheckPasswordAsync(user, request.OldPassword))
            {
                return new AuthDTO { IsAuthenticated = true, IsSucceded = false, ErrorDetails = "Old Password wasn't correct." };
            }
            if (request.NewPassword is not null)
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, request.NewPassword);
            }
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return new AuthDTO { IsAuthenticated = true, IsSucceded = false, ErrorDetails = "There was a problem with user password update." };
            }
            return new AuthDTO { IsAuthenticated = true, IsSucceded = true, SuccessMessage = "User passowrd has been updated" };
        }
    }
}