using Shop.Domain.Domain;

namespace Shop.Infrastructure.Repositories.Interfaces
{
    public interface IUserAddressRepository : IBaseRepository<UserAddress>
    {
        Task<IList<UserAddress>> GetUserAddressesWithUsers();
        Task<UserAddress> GetUserAddressByIdWithUser(Guid id);
    }
}