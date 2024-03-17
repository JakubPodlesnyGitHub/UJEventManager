using Microsoft.AspNet.Identity.EntityFramework;


namespace Shop.Domain.Domain
{
    internal class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Picture { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
