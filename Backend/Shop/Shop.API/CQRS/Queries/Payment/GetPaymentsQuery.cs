using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Queries.Payment
{
    public class GetPaymentsQuery : IRequest<IList<PaymentDTO>>
    {
    }
}