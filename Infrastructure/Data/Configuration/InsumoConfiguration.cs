using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class InsumoConfiguration : IEntityTypeConfiguration<Insumo>
    {
        public void Configure(EntityTypeBuilder<Insumo> builder)
        {
            builder.ToTable("Insumo");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.HasIndex(e => e.Nombre).IsUnique();
            builder.Property(e => e.Nombre);

            builder.Property(e => e.ValorUnit)
            .HasColumnType("double");

            builder.Property(e => e.stockMin)
            .HasColumnType("int");

            builder.Property(e => e.stockMax)
            .HasColumnType("int");
        }
    }
}