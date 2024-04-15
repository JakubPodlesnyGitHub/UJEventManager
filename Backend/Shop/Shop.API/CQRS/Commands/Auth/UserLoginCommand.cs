using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Commands.Auth
{
    public class UserLoginCommand : IRequest<AuthDTO>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public UserLoginCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}