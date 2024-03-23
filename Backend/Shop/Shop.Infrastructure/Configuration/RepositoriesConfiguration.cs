using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Infrastructure.DbContexts;
using Shop.Infrastructure.Repositories;
using Shop.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Configuration
{
    internal static class RepositoriesConfiguration
    {
        public static IServiceCollection AddRepositoriesConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}
