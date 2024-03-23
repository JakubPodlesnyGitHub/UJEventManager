using Microsoft.AspNet.Identity.EntityFramework;

namespace Shop.Domain.Domain
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Picture { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid IdRole { get; set; }

        public virtual ICollection<UserAddress> UserAddresses { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual UserRole RoleNavigation { get; set; }
    }
}