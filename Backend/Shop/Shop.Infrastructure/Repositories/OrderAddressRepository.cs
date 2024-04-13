using Microsoft.EntityFrameworkCore;
using Shop.Domain.Domain;
using Shop.Infrastructure.DbContexts;
using Shop.Infrastructure.Repositories.Interfaces;

namespace Shop.Infrastructure.Repositories
{
    public class OrderAddressRepository : BaseRepository<OrderAddress>, IOrderAddressRepository
    {
        private readonly ShopDbContext _context;
        public OrderAddressRepository(ShopDbContext shopDbContext) : base(shopDbContext)
        {
            _context = shopDbContext;
        }

        public async Task<IList<OrderAddress>> GetOrderAddressesWithShopOrders()
        {
            var result = _context.OrderAddresses.Include(o => o.ShopOrdersNavigation).ToList();
            return result;
        }

        public async Task<OrderAddress> GetOrderAddressByIdWithShopOrders(Guid id)
        {
            var result = await _context.OrderAddresses.Where(o => o.Id == id).Include(o => o.ShopOrdersNavigation).SingleOrDefaultAsync();
            return result;
        }
    }
}