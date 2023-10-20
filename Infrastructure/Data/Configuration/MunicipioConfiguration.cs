using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class MunicipioConfiguration : IEntityTypeConfiguration<Municipio>
    {
        public void Configure(EntityTypeBuilder<Municipio> builder)
        {
            builder.ToTable("Municipio");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(20);

            builder.HasOne(p => p.Departamento)
            .WithMany(p => p.Municipios)
            .HasForeignKey(p => p.IdDep);
        }
    }
}