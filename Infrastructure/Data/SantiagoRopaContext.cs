using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
public class SantiagoRopaContext : DbContext
{
    public SantiagoRopaContext(DbContextOptions<SantiagoRopaContext> options) : base(options)
    {
    }
    public DbSet<Cargo> Cargos {get; set;}
    public DbSet<Cliente> Clientes {get; set;}
    public DbSet<Color> Colors {get; set;}
    public DbSet<Departamento> Departamentos {get; set;}
    public DbSet<DetalleOrden> DetalleOrdenEs {get; set;}
    public DbSet<DetalleVenta> DetalleVentas {get; set;}
    public DbSet<Empleado> Empleados {get; set;}
    public DbSet<Empresa> Empresas {get; set;}
    public DbSet<Estado> Estados {get; set;}
    public DbSet<FormaPago> FormaPagos {get; set;}
    public DbSet<Genero> Generos {get; set;}
    public DbSet<Insumo> Insumos {get; set;}
    public DbSet<InsumoPrenda> InsumoPrendas {get; set;}
    public DbSet<InsumoProveedor> InsumoProveedores {get; set;}
    public DbSet<Inventario> Inventarios {get; set;}
    public DbSet<InventarioTalla> InventarioTallas {get; set;}
    public DbSet<Municipio> Municipios {get; set;}
    public DbSet<Orden> Ordenes {get; set;}
    public DbSet<Pais> Paises {get; set;}
    public DbSet<Prenda> Prendas {get; set;}
    public DbSet<Proveedor> Proveedores {get; set;}
    public DbSet<Talla> Tallas {get; set;}
    public DbSet<TipoEstado> TipoEstados {get; set;}
    public DbSet<TipoPersona> TipoPersonas {get; set;}
    public DbSet<TipoProteccion> TipoProtecciones {get; set;}
    public DbSet<Venta> Ventas {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // modelBuilder.Entity<InsumoPrenda>(
        // eb =>
        // {
        //     eb.HasNoKey();
        //     eb.ToView("View_InsumoKey");
        //     eb.Property(v => v.IdInsumo);
        // });

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
}