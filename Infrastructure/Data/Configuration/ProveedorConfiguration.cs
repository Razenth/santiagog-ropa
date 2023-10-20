using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            builder.ToTable("Proveedor");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.HasIndex(e => e.NitProveedor).IsUnique();
            builder.Property(e => e.NitProveedor);

            builder.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(20);

            builder.HasOne(p => p.TipoPersona)
            .WithMany(p => p.Proveedores)
            .HasForeignKey(p => p.IdTipoPersona);

            builder.HasOne(p => p.Municipio)
            .WithMany(p => p.Proveedores)
            .HasForeignKey(p => p.IdMunicipio);
        }
    }
}