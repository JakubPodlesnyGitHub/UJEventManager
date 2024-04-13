using Microsoft.EntityFrameworkCore;
using Shop.Domain.Domain;
using Shop.Infrastructure.DbContexts;
using Shop.Infrastructure.Repositories.Interfaces;

namespace Shop.Infrastructure.Repositories
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        private readonly ShopDbContext _context;
        public PaymentRepository(ShopDbContext shopDbContext) : base(shopDbContext)
        {
            _context = shopDbContext;
        }

        public async Task<IList<Payment>> GetPaymentsWithUserAndShopOrders()
        {
            var result = await _context.Payments.Include(p => p.UserNavigation).Include(p => p.ShopOrdersNavigation).ToArrayAsync();
            return result;
        }
        public async Task<Payment> GetPaymentByIdWithUserAndShopOrders(Guid id)
        {
            var result = await _context.Payments.Where(p => p.Id == id).Include(p => p.UserNavigation).Include(p => p.ShopOrdersNavigation).SingleOrDefaultAsync();
            return result;
        }

    }
}