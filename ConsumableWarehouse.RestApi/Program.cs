using ConsumableWarehouse.Application;
using ConsumableWarehouse.Application.Authentication;
using ConsumableWarehouse.Application.Services;
using ConsumableWarehouse.DataPersistence;
using ConsumableWarehouse.Domain.Interfaces;
using ConsumableWarehouse.Domain.Interfaces.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserContext, UserContext>();

builder.Services.AddScoped<IDataContext, DataContext>();

builder.Services.AddScoped<IWishlistService, WishlistService>();

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Title = "Consumable Warehouse API";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
