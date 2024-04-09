using Microsoft.EntityFrameworkCore;
using Shop.Domain.Domain;
using Shop.Infrastructure.DbContexts;
using Shop.Infrastructure.Repositories.Interfaces;

namespace Shop.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ShopDbContext _context;
        public UserRepository(ShopDbContext shopDbContext) : base(shopDbContext)
        {
            _context = shopDbContext;
        }
        public async Task<IList<User>> GetUsersWithPaymentsAndUserAddressesAndShopOrdrders()
        {
            var result = await _context.Users.Include(u => u.UserAddressesNavigation).Include(u => u.PaymentsNavigation).Include(u => u.ShopOrdersNavigation).ToListAsync();
            return result;
        }

        public async Task<User> GetUserByIdWithPaymentsAndUserAddressesAndShopOrdrders(Guid id)
        {
            var result = await _context.Users.Where(u => u.Id == id)
                .Include(u => u.UserAddressesNavigation)
                .Include(u => u.PaymentsNavigation)
                .Include(u => u.ShopOrdersNavigation).SingleOrDefaultAsync();
            return result;
        }

        public async Task<User> GetUserByEmailWithPaymentsAndUserAddressesAndShopOrdrders(string email)
        {
            var result = await _context.Users.Where(u => u.Email.Equals(email))
                .Include(u => u.UserAddressesNavigation)
                .Include(u => u.PaymentsNavigation)
                .Include(u => u.ShopOrdersNavigation).SingleOrDefaultAsync();
            return result;
        }
    }
}