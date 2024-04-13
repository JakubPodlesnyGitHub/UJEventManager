using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Commands.Auth
{
    public class UserRegisterCommand : IRequest<AuthDTO>
    {
    }
}