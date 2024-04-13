using AutoMapper;
using MediatR;
using Shop.API.CQRS.Commands.Payment;
using Shop.API.CQRS.Queries.Payment;
using Shop.Domain.Domain;
using Shop.Infrastructure.Repositories.Interfaces;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Handlers
{
    public class PaymentHandler :
        IRequestHandler<GetPaymentsQuery, IList<PaymentDTO>>,
        IRequestHandler<GetPaymentByIdQuery, PaymentDTO>,
        IRequestHandler<AddedPaymentCommand, PaymentDTO>,
        IRequestHandler<EditedPaymentCommand, PaymentDTO>,
        IRequestHandler<DeletedPaymentCommand, PaymentDTO>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;

        public PaymentHandler(IMapper mapper, IPaymentRepository paymentRepository)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
        }

        public async Task<IList<PaymentDTO>> Handle(GetPaymentsQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IList<PaymentDTO>>(await _paymentRepository.GetPaymentsWithUserAndShopOrders());
        }

        public async Task<PaymentDTO> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken)
        {
            var searchPayment = await _paymentRepository.GetPaymentByIdWithUserAndShopOrders(request.Id);
            if (searchPayment is null)
            {
                throw new NotImplementedException();
            }
            return _mapper.Map<PaymentDTO>(searchPayment);
        }

        public async Task<PaymentDTO> Handle(AddedPaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = _paymentRepository.Insert(_mapper.Map<Payment>(request));
            await _paymentRepository.Commit();
            return _mapper.Map<PaymentDTO>(payment);
        }

        public async Task<PaymentDTO> Handle(EditedPaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = await _paymentRepository.GetById(request.Id);
            if (payment is null)
            {
                throw new NotImplementedException();
            }

            payment.PaymentMethod = request.PaymentMethod;
            payment.Amount = request.Amount;
            payment.Data = request.Data;
            payment.IdUser = request.IdUser;

            _paymentRepository.Update(payment);
            await _paymentRepository.Commit();
            return _mapper.Map<PaymentDTO>(payment);
        }

        public async Task<PaymentDTO> Handle(DeletedPaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = await _paymentRepository.GetById(request.Id);
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