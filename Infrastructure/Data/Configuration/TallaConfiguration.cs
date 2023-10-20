using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class TallaConfiguration : IEntityTypeConfiguration<Talla>
    {
        public void Configure(EntityTypeBuilder<Talla> builder)
        {
            builder.ToTable("Talla");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.HasIndex(e => e.Descripcion).IsUnique();
            builder.Property(e => e.Descripcion)
            .IsRequired()
            .HasMaxLength(150);
        }
    }
}