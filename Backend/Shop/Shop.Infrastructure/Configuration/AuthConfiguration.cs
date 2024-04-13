using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shop.Infrastructure.ConfigurationModels;
using Shop.Infrastructure.Services;
using Shop.Infrastructure.Services.Interfaces;
using System.Text;

namespace Shop.Infrastructure.Configuration
{
    internal static class AuthConfiguration
    {
        public static IServiceCollection AddAuthConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JWTConfigurationModel>(configuration.GetSection("JwtSettings"))
               .AddSingleton(s => s.GetRequiredService<IOptions<JWTConfigurationModel>>().Value);

            services.AddScoped<ITokenService, TokenService>();

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddIdentityServerJwt()
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.FromSeconds(20),

                    ValidIssuer = configuration.GetSection("JwtSettings")["ValidIssuer"],
                    ValidAudience = configuration.GetSection("JwtSettings")["ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("JwtSettings")["SecurityKey"]))
                };

                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });
            return services;
        }
    }
}