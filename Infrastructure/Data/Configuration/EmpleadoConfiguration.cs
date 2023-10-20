using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.ToTable("Empleado");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.HasIndex(e => e.IdEmp).IsUnique();
            builder.Property(e => e.IdEmp);

            builder.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(20);

            builder.HasOne(p => p.Cargo)
            .WithMany(p => p.Empleados)
            .HasForeignKey(p => p.IdCargo);

            builder.Property(e => e.FechaIngreso)
            .HasColumnType("DateTime");

            builder.HasOne(p => p.Municipio)
            .WithMany(p => p.Empleados)
            .HasForeignKey(p => p.IdMunicipio);
        }
    }
}