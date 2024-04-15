using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Commands.UserAddress
{
    public class DeletedUserAdressCommand : IRequest<UserAddressDTO>
    {
        public Guid Id { get; set; }

        public DeletedUserAdressCommand(Guid id)
        {
            Id = id;
        }
    }
}