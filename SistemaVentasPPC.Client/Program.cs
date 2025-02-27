using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using Shared.Models;
using Shared.Repositories;
using SistemaVentasPPC.Client.Service;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
});

builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<IClientService<Productos>, ProductoClientService>();
builder.Services.AddScoped<IClientService<Facturaciones>, FacturacionesClientService>();
builder.Services.AddScoped<IClientService<Configuraciones>, ConfiguracionesClientService>();
builder.Services.AddScoped<IClientService<MetodoPagos>, MetodoPagosClientService>();


await builder.Build().RunAsync();
