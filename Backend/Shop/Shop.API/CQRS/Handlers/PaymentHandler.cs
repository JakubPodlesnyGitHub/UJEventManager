using AutoMapper;
using Shop.API.CQRS.Commands.Payment;
using Shop.API.CQRS.Handlers.Interfaces;
using Shop.API.CQRS.Queries.Payment;
using Shop.Domain.Domain;
using Shop.Infrastructure.Repositories.Interfaces;
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
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;

        public async Task<IList<PaymentDTO>> HandleAsync(GetPaymentsQuery command)
        {
            return _mapper.Map<IList<PaymentDTO>>(await _paymentRepository.GetAll());
        }

        public async Task<PaymentDTO> HandleAsync(GetPaymentByIdQuery command)
        {
            var searchPayment = await _paymentRepository.GetById(command.Id);
            if (searchPayment is null)
            {
                throw new NotImplementedException();
            }
            return _mapper.Map<PaymentDTO>(searchPayment);
        }

        public async Task<PaymentDTO> HandleAsync(AddedPaymentCommand command)
        {
            var payment = _paymentRepository.Insert(_mapper.Map<Payment>(command));
            await _paymentRepository.Commit();
            return _mapper.Map<PaymentDTO>(payment);
        }

        public async Task<PaymentDTO> HandleAsync(EditedPaymentCommand command)
        {
            var payment = await _paymentRepository.GetById(command.Id);
            if (payment is null)
            {
                throw new NotImplementedException();
            }

            payment.PaymentMethod = command.PaymentMethod;
            payment.Amount = command.Amount;
            payment.Data = command.Data;
            payment.IdUser = command.IdUser;

            _paymentRepository.Update(payment);
            await _paymentRepository.Commit();
            return _mapper.Map<PaymentDTO>(payment);
        }

        public async Task<PaymentDTO> HandleAsync(DeletedPaymentCommand command)
        {
            var payment = await _paymentRepository.GetById(command.Id);
            if (payment is null)
            {
                throw new NotImplementedException();
            }
            await _paymentRepository.Delete(payment);
            await _paymentRepository.Commit();

            return _mapper.Map<PaymentDTO>(payment);
        }
    }
}