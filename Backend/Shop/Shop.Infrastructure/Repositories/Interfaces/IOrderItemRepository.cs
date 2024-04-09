using Shop.Domain.Domain;

namespace Shop.Infrastructure.Repositories.Interfaces
{
    public interface IOrderItemRepository : IBaseRepository<OrderItem>
    {
        Task<IList<OrderItem>> GetOrderItemsWithOrdersAndProducts();
        Task<OrderItem> GetOrderItemByIdWithOrdersAndProducts(Guid id);
    }
}