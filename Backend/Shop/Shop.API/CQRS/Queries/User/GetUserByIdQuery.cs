using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Queries.User
{
    public class GetUserByIdQuery : IRequest<UserDTO>
    {
        public Guid Id { get; set; }

        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}