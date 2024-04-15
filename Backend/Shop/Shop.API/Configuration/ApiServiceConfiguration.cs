using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.Infrastructure.DbContexts;
using System.Reflection;

namespace Shop.API.Configuration
{
    public static class ApiServiceConfiguration
    {
        public static IServiceCollection AddApiServiceLayerConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddDbConfiguration(configuration);
            return services;
        }
    }
}
