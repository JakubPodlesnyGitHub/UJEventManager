using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Commands.OrderAddress
{
    public class DeletedOrderAddressCommand : IRequest<OrderAddressDTO>
    {
        public Guid Id { get; set; }

        public DeletedOrderAddressCommand(Guid id)
        {
            Id = id;
        }
    }
}