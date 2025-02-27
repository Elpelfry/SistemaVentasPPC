using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace SistemaVentasPPC.DAL;

public class Contexto : DbContext
{
	public Contexto(DbContextOptions<Contexto> options) : base(options)
	{
	}

	public DbSet<Facturaciones> Facturaciones { get; set; }
	public DbSet<Productos> Productos { get; set; }
	public DbSet<MetodoPagos> MetodoPagos { get; set; }
	public DbSet<FacturacionDetalle> FacturacionDetalle { get; set; }
	public DbSet<Configuraciones> Configuraciones { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<MetodoPagos>().HasData(
			 new MetodoPagos { MetodoPagoId = 1, Nombre = "Efectivo" },
			 new MetodoPagos { MetodoPagoId = 2, Nombre = "Tarjeta" }
		);

		modelBuilder.Entity<Configuraciones>().HasData(
				new Configuraciones { 
				 ConfiguracionId = 1, Direccion = "", 
				 NFC ="", Imagen = null, ImagenUrl = "",
				 NombreEmpresa = "", Telefono = "", Nota = ""}
				);
	}
}