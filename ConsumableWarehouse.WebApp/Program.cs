using Blazored.Modal;
using ConsumableWarehouse.Application;
using ConsumableWarehouse.Application.Authentication;
using ConsumableWarehouse.Application.Services;
using ConsumableWarehouse.DataPersistence;
using ConsumableWarehouse.Domain.Interfaces;
using ConsumableWarehouse.Domain.Interfaces.Services;
using ConsumableWarehouse.WebApp.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserContext, UserContext>();

builder.Services.AddScoped<IDataContext, DataContext>();

builder.Services.AddScoped<IPartnerService, PartnerService>();
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();

builder.Services.AddBlazoredModal();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
