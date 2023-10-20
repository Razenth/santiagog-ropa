using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class GeneroConfiguration : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.ToTable("Genero");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.Descripcion)
            .IsRequired()
            .HasMaxLength(150);
        }
    }
}