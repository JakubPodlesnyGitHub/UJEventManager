using Microsoft.EntityFrameworkCore;
using Shop.API.Configuration.Db;
using Shop.Infrastructure.DbContexts;
using System.Reflection;

namespace Shop.API.Configuration
{
    public static class ApiServiceConfiguration
    {
        public static IServiceCollection AddApiServiceLayerConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddDbConfiguration(configuration);
            return services;
        }
    }
}
