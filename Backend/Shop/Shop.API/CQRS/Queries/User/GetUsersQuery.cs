using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Queries.User
{
    public class GetUsersQuery : IRequest<IList<UserDTO>>
    {
    }
}