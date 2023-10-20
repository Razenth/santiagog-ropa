using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class PrendaConfiguration : IEntityTypeConfiguration<Prenda>
    {
        public void Configure(EntityTypeBuilder<Prenda> builder)
        {
            builder.ToTable("Prenda");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.HasIndex(e => e.IdPrenda).IsUnique();
            builder.Property(e => e.IdPrenda);

            builder.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(20);

            builder.Property(e => e.valorVtaCop)
            .HasColumnType("double");

            builder.Property(e => e.valorVtaUsd)
            .HasColumnType("double");

            builder.HasOne(p => p.Estado)
            .WithMany(p => p.Prendas)
            .HasForeignKey(p => p.IdEstado);

            builder.HasOne(p => p.TipoProteccion)
            .WithMany(p => p.Prendas)
            .HasForeignKey(p => p.IdTipoProteccion);

            builder.HasOne(p => p.Genero)
            .WithMany(p => p.Prendas)
            .HasForeignKey(p => p.IdGenero);
        }
    }
}