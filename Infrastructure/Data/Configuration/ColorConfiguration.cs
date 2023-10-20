using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.ToTable("Color");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.Descripcion)
            .IsRequired()
            .HasMaxLength(150);

            
        }
    }
}