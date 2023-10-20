using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class InventarioTallaConfiguration : IEntityTypeConfiguration<InventarioTalla>
    {
        public void Configure(EntityTypeBuilder<InventarioTalla> builder)
        {
            builder.ToTable("InventarioTalla");

            builder.HasKey(e => new { e.IdInv, e.IdTalla});

            builder.HasOne(e => e.Inventario)
            .WithMany(e => e.InventarioTallas)
            .HasForeignKey(e => e.IdInv);

            builder.HasOne(e => e.Talla)
            .WithMany(e => e.InventarioTallas)
            .HasForeignKey(e => e.IdTalla);
        }
    }
}