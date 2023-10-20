using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class PaisConfiguration : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.ToTable("Pais");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(20);
        }
    }
}