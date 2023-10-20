using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class FormaPagoConfiguration : IEntityTypeConfiguration<FormaPago>
    {
        public void Configure(EntityTypeBuilder<FormaPago> builder)
        {
            builder.ToTable("FormaPago");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.Descripcion)
            .IsRequired()
            .HasMaxLength(150);
        }
    }
}