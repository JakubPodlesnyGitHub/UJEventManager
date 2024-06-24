using Shop.Domain.Domain;

namespace Shop.Infrastructure.Repositories.Interfaces
{
    public interface IProductAvailabilityRepository : IBaseRepository<ProductAvailability>
    {
        Task<IList<ProductAvailability>> GetProductsAvailabilitiesWithProducts();
        Task<ProductAvailability> GetProductAvailabilityByIdWithProduct(Guid id);
        Task<ProductAvailability> GetProductAvailabilityByProductIdWithProduct(Guid id);
    }
}