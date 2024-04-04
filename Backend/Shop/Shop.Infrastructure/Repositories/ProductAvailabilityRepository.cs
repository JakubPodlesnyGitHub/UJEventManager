using Shop.Domain.Domain;
using Shop.Infrastructure.DbContexts;
using Shop.Infrastructure.Repositories.Interfaces;

namespace Shop.Infrastructure.Repositories
{
    public class ProductAvailabilityRepository : BaseRepository<ProductAvailability>, IProductAvailabilityRepository
    {
        public ProductAvailabilityRepository(ShopDbContext shopDbContext) : base(shopDbContext)
        {
        }
    }
}