using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Commands.User
{
    public class DeletedUserCommand : IRequest<UserDTO>
    {
        public Guid Id { get; set; }

        public DeletedUserCommand(Guid id)
        {
            Id = id;
        }
    }
}