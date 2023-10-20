using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.ToTable("Estado");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.Descripcion)
            .IsRequired()
            .HasMaxLength(150);

            builder.HasOne(p => p.TipoEstado)
            .WithMany(p => p.Estados)
            .HasForeignKey(p => p.IdTipoEstado);
        }
    }
}