using Shop.Domain.Domain;

namespace Shop.Infrastructure.Repositories.Interfaces
{
    public interface IPaymentRepository : IBaseRepository<Payment>
    {
        Task<IList<Payment>> GetPaymentsWithUserAndShopOrders();

        Task<Payment> GetPaymentByIdWithUserAndShopOrders(Guid id);
    }
}