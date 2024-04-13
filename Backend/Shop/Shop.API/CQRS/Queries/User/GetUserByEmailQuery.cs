using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Queries.User
{
    public class GetUserByEmailQuery : IRequest<UserDTO>
    {
        public string Email { get; set; }

        public GetUserByEmailQuery(string email)
        {
            Email = email;
        }
    }
}