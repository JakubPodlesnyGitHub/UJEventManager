using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Queries.Payment
{
    public class GetPaymentByIdQuery : IRequest<PaymentDTO>
    {
        public Guid Id { get; set; }

        public GetPaymentByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}