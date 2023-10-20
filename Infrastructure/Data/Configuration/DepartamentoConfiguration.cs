using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.ToTable("Departamento");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(20);

            builder.HasOne(p => p.Pais)
            .WithMany(p => p.Departamentos)
            .HasForeignKey(p => p.IdPais);
        }
    }
}