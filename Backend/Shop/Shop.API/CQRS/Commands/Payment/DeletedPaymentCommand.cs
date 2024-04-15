using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Commands.Payment
{
    public class DeletedPaymentCommand : IRequest<PaymentDTO>
    {
        public Guid Id { get; set; }

        public DeletedPaymentCommand(Guid id)
        {
            Id = id;
        }
    }
}