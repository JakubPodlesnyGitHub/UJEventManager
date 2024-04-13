using Microsoft.EntityFrameworkCore;
using Shop.Domain.Domain;
using Shop.Infrastructure.DbContexts;
using Shop.Infrastructure.Repositories.Interfaces;

namespace Shop.Infrastructure.Repositories
{
    public class UserAddressRepository : BaseRepository<UserAddress>, IUserAddressRepository
    {
        private readonly ShopDbContext _context;
        public UserAddressRepository(ShopDbContext shopDbContext) : base(shopDbContext)
        {
            _context = shopDbContext;
        }

        public async Task<IList<UserAddress>> GetUserAddressesWithUsers()
        {
            var result = await _context.UserAddresses.Include(u => u.UserNavigation).ToListAsync();
            return result;
        }

        public async Task<UserAddress> GetUserAddressByIdWithUser(Guid id)
        {
            var result = await _context.UserAddresses.Where(u => u.Id == id).Include(u => u.UserNavigation).SingleOrDefaultAsync();
            return result;
        }
    }
}