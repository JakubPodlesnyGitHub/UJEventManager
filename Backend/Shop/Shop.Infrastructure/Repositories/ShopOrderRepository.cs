using Microsoft.EntityFrameworkCore;
using Shop.Domain.Domain;
using Shop.Infrastructure.DbContexts;
using Shop.Infrastructure.Repositories.Interfaces;

namespace Shop.Infrastructure.Repositories
{
    public class ShopOrderRepository : BaseRepository<ShopOrder>, IShopOrderRepository
    {
        private readonly ShopDbContext _context;
        public ShopOrderRepository(ShopDbContext shopDbContext) : base(shopDbContext)
        {
            _context = shopDbContext;
        }

        public async Task<IList<ShopOrder>> GetShopOrdersWithPaymentAndOrderAddressAndUserAndOrderItems()
        {
            var result = await _context.ShopOrders
                .Include(s => s.OrderAddressNavigation)
                .Include(s => s.UserNavigation)
                .Include(s => s.PaymentNavigation)
                .Include(s => s.PaymentNavigation).ToListAsync();

            return result;
        }

        public async Task<ShopOrder> GetShopOrderByIdWithPaymentAndOrderAddressAndUserAndOrderItems(Guid id)
        {
            var result = await _context.ShopOrders
                .Where(s => s.Id == id)
                .Include(s => s.OrderAddressNavigation)
                .Include(s => s.UserNavigation)
                .Include(s => s.PaymentNavigation)
                .Include(s => s.PaymentNavigation).SingleOrDefaultAsync();

            return result;
        }
    }
}