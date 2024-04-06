using Microsoft.EntityFrameworkCore;
using Shop.API.Configuration;
using Shop.API.Configuration.Db;
using Shop.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureConfiguration(builder.Configuration);
builder.Services.AddApiServiceLayerConfiguration(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
