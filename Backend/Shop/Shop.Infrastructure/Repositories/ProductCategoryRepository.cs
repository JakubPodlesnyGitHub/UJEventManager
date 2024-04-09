using Microsoft.EntityFrameworkCore;
using Shop.Domain.Domain;
using Shop.Infrastructure.DbContexts;
using Shop.Infrastructure.Repositories.Interfaces;

namespace Shop.Infrastructure.Repositories
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory>, IProductCategoryRepository
    {
        private readonly ShopDbContext _context;
        public ProductCategoryRepository(ShopDbContext shopDbContext) : base(shopDbContext)
        {
            _context = shopDbContext;
        }

        public async Task<IList<ProductCategory>> GetProductsCategoriesWithProductAndCategory()
        {
            var result = await _context.ProductsCategories.Include(pc => pc.ProductNavigation).Include(pc => pc.CategoryNavigation).ToListAsync();
            return result;
        }

        public async Task<ProductCategory> GetProductCategoryByIdsWithProductAndCategory(Guid idProduct,Guid idCategory)
        {
            var result = await _context.ProductsCategories.Where(pc => pc.IdProduct == idProduct && pc.IdCategory == idCategory)
                .Include(pc => pc.ProductNavigation).Include(pc => pc.CategoryNavigation).SingleOrDefaultAsync();
            return result;
        }
    }
}