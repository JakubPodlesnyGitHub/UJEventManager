using Shop.Domain.Domain;
using Shop.Infrastructure.DbContexts;
using Shop.Infrastructure.Repositories.Interfaces;

namespace Shop.Infrastructure.Repositories
{
    public class ShopOrderRepository : BaseRepository<ShopOrder>, IShopOrderRepository
    {
        public ShopOrderRepository(ShopDbContext shopDbContext) : base(shopDbContext)
        {
        }
    }
}