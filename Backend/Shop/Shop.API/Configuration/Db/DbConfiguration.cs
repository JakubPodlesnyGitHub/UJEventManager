using Microsoft.EntityFrameworkCore;
using ShopDbContext = Shop.Infrastructure.DbContexts.ShopDbContext;

namespace Shop.API.Configuration.Db
{
    public static class DbConfiguration
    {
        public static IServiceCollection AddDbConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DatabaseConnectionString");

            services.AddDbContext<ShopDbContext>(options =>
                options.UseSqlServer(connectionString));

          services.AddDatabaseDeveloperPageExceptionFilter();
            return services;
        }
    }
}
