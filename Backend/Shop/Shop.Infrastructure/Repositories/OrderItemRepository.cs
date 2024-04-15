using Microsoft.EntityFrameworkCore;
using Shop.Domain.Domain;
using Shop.Infrastructure.DbContexts;
using Shop.Infrastructure.Repositories.Interfaces;

namespace Shop.Infrastructure.Repositories
{
    public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        private readonly ShopDbContext _context;
        public OrderItemRepository(ShopDbContext shopDbContext) : base(shopDbContext)
        {
            _context = shopDbContext;
        }

        public async Task<IList<OrderItem>> GetOrderItemsWithOrdersAndProducts()
        {
            var result = await _context.OrderItems.Include(o => o.ShopOrderNavigation).Include(o => o.ProductNavigation).ToListAsync();
            return result;
        }

        public async Task<OrderItem> GetOrderItemByIdWithOrdersAndProducts(Guid id)
        {
            var result = await _context.OrderItems.Where(o => o.IdOrder == id).Include(o => o.ShopOrderNavigation).Include(o => o.ProductNavigation).SingleOrDefaultAsync();
            return result;
        }
    }
}