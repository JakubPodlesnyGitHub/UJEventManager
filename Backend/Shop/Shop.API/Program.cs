using Microsoft.AspNetCore.Identity;
using Shop.API.ApiFilters;
using Shop.API.Configuration;
using Shop.Domain.Domain;
using Shop.Infrastructure.Configuration;
using Shop.Infrastructure.DbContexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentity<User, IdentityRole<Guid>>()
            .AddEntityFrameworkStores<ShopDbContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();

builder.Services.AddInfrastructureLayerConfiguration(builder.Configuration);
builder.Services.AddApiServiceLayerConfiguration(builder.Configuration);

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<ApiExceptionFilter>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
