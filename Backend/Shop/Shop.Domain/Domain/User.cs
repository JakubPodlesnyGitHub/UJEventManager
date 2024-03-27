using Microsoft.AspNetCore.Identity;

namespace Shop.Domain.Domain
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Picture { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual ICollection<UserAddress> UserAddressesNavigation { get; set; }
        public virtual ICollection<Payment> PaymentsNavigation { get; set; }
        public virtual ICollection<ShopOrder> ShopOrdersNavigation { get; set; }
    }
}