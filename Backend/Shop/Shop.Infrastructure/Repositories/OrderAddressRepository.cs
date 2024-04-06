using Shop.Domain.Domain;
using Shop.Infrastructure.DbContexts;
using Shop.Infrastructure.Repositories.Interfaces;

namespace Shop.Infrastructure.Repositories
{
    public class OrderAddressRepository : BaseRepository<OrderAddress>, IOrderAddressRepository
    {
        public OrderAddressRepository(ShopDbContext shopDbContext) : base(shopDbContext)
        {
        }
    }
}