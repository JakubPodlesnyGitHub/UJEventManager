using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shop.Infrastructure.Configuration
{
    public static class InfrastructureLayerConfiguration
    {
        public static IServiceCollection AddInfrastructureLayerConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositoriesConfiguration(configuration);
            return services;
        }
    }
}