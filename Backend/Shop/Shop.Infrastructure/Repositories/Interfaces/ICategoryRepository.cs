using Shop.Domain.Domain;

namespace Shop.Infrastructure.Repositories.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<IList<Category>> GetCategoriesWithProducts();
        Task<Category> GetCategoryByIdWithProducts(Guid id);
    }
}