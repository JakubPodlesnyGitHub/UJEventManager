using Microsoft.EntityFrameworkCore;
using Shop.Domain.Domain;
using Shop.Infrastructure.DbContexts;
using Shop.Infrastructure.Repositories.Interfaces;

namespace Shop.Infrastructure.Repositories
{
    public class ProductAvailabilityRepository : BaseRepository<ProductAvailability>, IProductAvailabilityRepository
    {
        private readonly ShopDbContext _context;
        public ProductAvailabilityRepository(ShopDbContext shopDbContext) : base(shopDbContext)
        {
            _context = shopDbContext;
        }

        public async Task<IList<ProductAvailability>> GetProductsAvailabilitiesWithProducts()
        {
            var result = await _context.ProductAvailabilities.Include(p => p.ProductNavigation).ToListAsync();
            return result;
        }

        public async Task<ProductAvailability> GetProductAvailabilityByIdWithProduct(Guid id)
        {
            var result = await _context.ProductAvailabilities.Where(p => p.Id == id).Include(p => p.ProductNavigation).SingleOrDefaultAsync();
            return result;
        }

        public async Task<ProductAvailability> GetProductAvailabilityByProductIdWithProduct(Guid id)
        {
            var result = await _context.ProductAvailabilities.Where(p => p.IdProduct == id).Include(p => p.ProductNavigation).SingleOrDefaultAsync();
            return result;
        }
    }
}