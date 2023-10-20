using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class VentaConfiguration : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder.ToTable("Venta");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.Fecha)
            .HasColumnType("DateTime");

            builder.HasOne(p => p.Empleado)
            .WithMany(p => p.Ventas)
            .HasForeignKey(p => p.IdEmpleado);

            builder.HasOne(p => p.Cliente)
            .WithMany(p => p.Ventas)
            .HasForeignKey(p => p.IdCliente);

            builder.HasOne(p => p.FormaPago)
            .WithMany(p => p.Ventas)
            .HasForeignKey(p => p.IdFormaPago);
        }
    }
}