using Shop.Domain.Domain;

namespace Shop.Infrastructure.Repositories.Interfaces
{
    public interface IOrderAddressRepository : IBaseRepository<OrderAddress>
    {
        Task<IList<OrderAddress>> GetOrderAddressesWithShopOrders();
        Task<OrderAddress> GetOrderAddressByIdWithShopOrders(Guid id);
    }
}