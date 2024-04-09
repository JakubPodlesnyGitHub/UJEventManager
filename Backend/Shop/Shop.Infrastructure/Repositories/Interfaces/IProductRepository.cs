using Shop.Domain.Domain;

namespace Shop.Infrastructure.Repositories.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IList<Product>> GetProductsWithProductAvailabilitesAndCategory();
        Task<Product> GetProductByIdWithProductAvailabilitesAndCategory(Guid id);
    }
}