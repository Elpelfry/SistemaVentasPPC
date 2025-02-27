using Microsoft.EntityFrameworkCore;
using Radzen;
using Shared.Models;
using Shared.Repositories;
using SistemaVentasPPC.Client.Pages;
using SistemaVentasPPC.Client.Service;
using SistemaVentasPPC.Components;
using SistemaVentasPPC.DAL;
using SistemaVentasPPC.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveWebAssemblyComponents();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var ConStr = builder.Configuration.GetConnectionString("ConStr");

builder.Services.AddDbContext<Contexto>(options =>
    options.UseSqlite(ConStr));

builder.Services.AddScoped(a =>
	new HttpClient
	{
		BaseAddress = new Uri((builder.Configuration.GetSection("RutaApi")!.Value)!)
	});

builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<IServerService<Productos>, ProductosService>();
builder.Services.AddScoped<IServerService<Facturaciones>, FacturacionesService>();
builder.Services.AddScoped<IServerService<MetodoPagos>, MetodoPagosService>();
builder.Services.AddScoped<IServerService<Configuraciones>, ConfiguracionesService>();

builder.Services.AddScoped<IClientService<Productos>, ProductoClientService>();
builder.Services.AddScoped<IClientService<Facturaciones>, FacturacionesClientService>();
builder.Services.AddScoped<IClientService<Configuraciones>, ConfiguracionesClientService>();
builder.Services.AddScoped<IClientService<MetodoPagos>, MetodoPagosClientService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

if (app.Environment.IsDevelopment())
{
	app.UseWebAssemblyDebugging();
}
else
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	app.UseHsts();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseStaticFiles();
app.UseAntiforgery();

app.UseCors(builder => builder
    .AllowAnyOrigin()
        .AllowAnyMethod()
            .AllowAnyHeader());

app.MapRazorComponents<App>()
	.AddInteractiveWebAssemblyRenderMode()
	.AddAdditionalAssemblies(typeof(SistemaVentasPPC.Client._Imports).Assembly);


app.Run();
