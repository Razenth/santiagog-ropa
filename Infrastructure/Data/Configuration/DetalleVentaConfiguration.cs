using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class DetalleVentaConfiguration : IEntityTypeConfiguration<DetalleVenta>
    {
        public void Configure(EntityTypeBuilder<DetalleVenta> builder)
        {
            builder.ToTable("DetalleVenta");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.HasOne(p => p.Venta)
            .WithMany(p => p.DetalleVentas)
            .HasForeignKey(p => p.IdVenta);

            builder.HasOne(p => p.Producto)
            .WithMany(p => p.DetalleVentas)
            .HasForeignKey(p => p.IdProducto);

            builder.HasOne(p => p.Talla)
            .WithMany(p => p.DetalleVentas)
            .HasForeignKey(p => p.IdTalla);

            builder.Property(e => e.Cantidad)
            .HasColumnType("int");

            builder.Property(e => e.ValorUnit)
            .HasColumnType("double");
        }
    }
}