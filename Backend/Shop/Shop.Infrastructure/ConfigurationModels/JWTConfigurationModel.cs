namespace Shop.Infrastructure.ConfigurationModels
{
    public class JWTConfigurationModel
    {
        public string SecurityKey { get; set; }
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public int ExpiryInMinutes { get; set; }
    }
}