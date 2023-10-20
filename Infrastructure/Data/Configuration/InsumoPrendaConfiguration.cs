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
            builder.HasKey(e => new { e.IdPrenda, e.IdInsumo});

            builder.HasOne(e => e.Insumo)
            .WithMany(e => e.InsumoPrendas)
            .HasForeignKey(e => e.IdInsumo);

            builder.HasOne(e => e.Prenda)
            .WithMany(e => e.InsumoPrendas)
            .HasForeignKey(e => e.IdPrenda);

        }
    }
}