using Shop.Domain.Domain;

namespace Shop.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<IList<User>> GetUsersWithPaymentsAndUserAddressesAndShopOrdrders();
        Task<User> GetUserByIdWithPaymentsAndUserAddressesAndShopOrdrders(Guid id);
        Task<User> GetUserByEmailWithPaymentsAndUserAddressesAndShopOrdrders(string email);
    }
}