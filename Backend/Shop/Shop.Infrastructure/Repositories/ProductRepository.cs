using Microsoft.EntityFrameworkCore;
using Shop.Domain.Domain;
using Shop.Infrastructure.DbContexts;
using Shop.Infrastructure.Repositories.Interfaces;

namespace Shop.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly ShopDbContext _context;
        public ProductRepository(ShopDbContext shopDbContext) : base(shopDbContext)
        {
            _context = shopDbContext;
        }

        public async Task<IList<Product>> GetProductsWithProductAvailabilitesAndCategory()
        {
            var result = await _context.Products.Include(p => p.ProductAvailabilitiesNavigation).Include(p => p.ProductCategoriesNavigation).ThenInclude(pc => pc.CategoryNavigation).ToListAsync();
            return result;
        }

        public async Task<Product> GetProductByIdWithProductAvailabilitesAndCategory(Guid id)
        {
            var result = await _context.Products.Where(p => p.Id == id).Include(p => p.ProductAvailabilitiesNavigation).Include(p => p.ProductCategoriesNavigation).ThenInclude(pc => pc.CategoryNavigation).SingleOrDefaultAsync();
            return result;
        }
    }
}