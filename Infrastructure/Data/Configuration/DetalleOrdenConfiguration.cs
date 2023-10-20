using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class DetalleOrdenConfiguration : IEntityTypeConfiguration<DetalleOrden>
    {
        public void Configure(EntityTypeBuilder<DetalleOrden> builder)
        {
            builder.ToTable("DetalleOrden");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.HasOne(p => p.Orden)
            .WithMany(p => p.DetalleOrdenes)
            .HasForeignKey(p => p.IdOrden);

            builder.HasOne(p => p.Prenda)
            .WithMany(p => p.DetallerOrdenes)
            .HasForeignKey(p => p.IdPrenda);

            builder.Property(e => e.CantidadProducir)
            .HasColumnType("int");

            builder.HasOne(p => p.Color)
            .WithMany(p => p.DetalleOrdenes)
            .HasForeignKey(p => p.IdColor);

            builder.Property(e => e.CantidadProducida)
            .HasColumnType("int");

            builder.HasOne(p => p.Estado)
            .WithMany(p => p.DetalleOrdenes)
            .HasForeignKey(p => p.IdEstado);
        }
    }
}