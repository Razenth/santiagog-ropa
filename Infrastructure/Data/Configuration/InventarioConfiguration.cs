using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class InventarioConfiguration : IEntityTypeConfiguration<Inventario>
    {
        public void Configure(EntityTypeBuilder<Inventario> builder)
        {
            builder.ToTable("Inventario");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.HasIndex(e => e.CodInv).IsUnique();
            builder.Property(e => e.CodInv);

            builder.HasOne(p => p.Prenda)
            .WithMany(p => p.Inventarios)
            .HasForeignKey(p => p.IdPrenda);

            builder.Property(e => e.valorVtaCop)
            .HasColumnType("double");

            builder.Property(e => e.valorVtaUsd)
            .HasColumnType("double");
        }
    }
}