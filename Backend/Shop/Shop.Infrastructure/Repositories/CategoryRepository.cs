using Microsoft.EntityFrameworkCore;
using Shop.Domain.Domain;
using Shop.Infrastructure.DbContexts;
using Shop.Infrastructure.Repositories.Interfaces;

namespace Shop.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly ShopDbContext _context;
        public CategoryRepository(ShopDbContext shopDbContext) : base(shopDbContext)
        {
            _context = shopDbContext;
        }

        public async Task<IList<Category>> GetCategoriesWithProducts()
        {
             
            var result = await _context.Categories.Include(x => x.ProductCategoriesNavigation).ThenInclude(pc => pc.ProductNavigation).ToListAsync();
            return result;
        }

        public async Task<Category> GetCategoryByIdWithProducts(Guid id)
        {
            var result = await _context.Categories.Where(x => x.Id == id).Include(x => x.ProductCategoriesNavigation).ThenInclude(pc => pc.ProductNavigation).SingleOrDefaultAsync();
            return result;
        }
    }
}