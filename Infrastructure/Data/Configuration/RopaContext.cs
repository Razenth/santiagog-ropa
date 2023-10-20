using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Configuration;
public class RopaContext : DbContext
{
    public RopaContext(DbContextOptions options) : base(options)
    {
    }

    //  public DbSet<> s {get; set;}  //Entidad EntidadPlural

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*modelBuilder.Entity<Cliente>()
        .HasOne(a => a.ClienteDireccion)
        .WithOne(b => b.Clientes)
        .HasForeignKey<ClienteDireccion>(b => b.IdCliente);*/

        base.OnModelCreating(modelBuilder);
    }
}

