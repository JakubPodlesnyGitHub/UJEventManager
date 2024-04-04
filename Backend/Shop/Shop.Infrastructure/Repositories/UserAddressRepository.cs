using Shop.Domain.Domain;
using Shop.Infrastructure.DbContexts;
using Shop.Infrastructure.Repositories.Interfaces;

namespace Shop.Infrastructure.Repositories
{
    public class UserAddressRepository : BaseRepository<UserAddress>, IUserAddressRepository
    {
        public UserAddressRepository(ShopDbContext shopDbContext) : base(shopDbContext)
        {
        }
    }
}