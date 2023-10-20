using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class InsumoPrendaConfiguration : IEntityTypeConfiguration<InsumoPrenda>
    {
        public void Configure(EntityTypeBuilder<InsumoPrenda> builder)
        {
            builder.ToTable("InsumoPrenda");

            builder.HasKey(e => new { e.IdInsumo, e.IdPrenda});

            builder.HasOne(e => e.Insumos)
            .WithMany(e => e.InsumoPrendas)
            .HasForeignKey(e => e.IdInsumo);

            builder.HasOne(e => e.Prendas)
            .WithMany(e => e.InsumoPrendas)
            .HasForeignKey(e => e.IdPrenda);

        }
    }
}