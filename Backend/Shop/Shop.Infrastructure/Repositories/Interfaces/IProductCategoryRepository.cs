using Shop.Domain.Domain;

namespace Shop.Infrastructure.Repositories.Interfaces
{
    public interface IProductCategoryRepository : IBaseRepository<ProductCategory>
    {
        Task<IList<ProductCategory>> GetProductsCategoriesWithProductAndCategory();
        Task<ProductCategory> GetProductCategoryByIdsWithProductAndCategory(Guid idProduct, Guid idCategory);
    }
}