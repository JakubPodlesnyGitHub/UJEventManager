using Microsoft.AspNetCore.Identity;
using Shop.API.ApiFilters;
using Shop.API.Configuration;
using Shop.Domain.Domain;
using Shop.Infrastructure.Configuration;
using Shop.Infrastructure.DbContexts;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentity<User, IdentityRole<Guid>>()
            .AddEntityFrameworkStores<ShopDbContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();

builder.Services.AddInfrastructureLayerConfiguration(builder.Configuration);
builder.Services.AddApiServiceLayerConfiguration(builder.Configuration);

builder.Services.AddControllers().AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    opt.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "ShopAPI");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
