using Shop.API.CQRS.Commands.Payment;
using Shop.API.CQRS.Queries.Payment;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Handlers
{
    public class PaymentHandler :
        IQueryBaseHandler<GetPaymentsQuery, IList<PaymentDTO>>,
        IQueryBaseHandler<GetPaymentByIdQuery, PaymentDTO>,
        ICommandBaseHandler<AddedPaymentCommand, PaymentDTO>,
        ICommandBaseHandler<EditedPaymentCommand, PaymentDTO>,
        ICommandBaseHandler<DeletedPaymentCommand, PaymentDTO>
    {
        public Task<IList<PaymentDTO>> HandleAsync(GetPaymentsQuery command)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentDTO> HandleAsync(GetPaymentByIdQuery command)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentDTO> HandleAsync(AddedPaymentCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentDTO> HandleAsync(EditedPaymentCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentDTO> HandleAsync(DeletedPaymentCommand command)
        {
            throw new NotImplementedException();
        }
    }
}