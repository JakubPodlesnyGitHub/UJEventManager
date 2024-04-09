using Shop.Domain.Domain;

namespace Shop.Infrastructure.Repositories.Interfaces
{
    public interface IShopOrderRepository : IBaseRepository<ShopOrder>
    {
        Task<IList<ShopOrder>> GetShopOrdersWithPaymentAndOrderAddressAndUserAndOrderItems();
        Task<ShopOrder> GetShopOrderByIdWithPaymentAndOrderAddressAndUserAndOrderItems(Guid id);
    }
}