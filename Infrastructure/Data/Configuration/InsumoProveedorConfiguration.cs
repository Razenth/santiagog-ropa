using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class InsumoProveedorConfiguration : IEntityTypeConfiguration<InsumoProveedor>
    {
        public void Configure(EntityTypeBuilder<InsumoProveedor> builder)
        {
            builder.ToTable("InsumoProveedor");

            builder.HasKey(e => new { e.IdInsumo, e.IdProveedor});

            builder.HasOne(e => e.Insumo)
            .WithMany(e => e.InsumoProveedores)
            .HasForeignKey(e => e.IdInsumo);

            builder.HasOne(e => e.Proveedor)
            .WithMany(e => e.InsumoProveedores)
            .HasForeignKey(e => e.IdProveedor);
        }
    }
}