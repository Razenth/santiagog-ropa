using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuracion
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.HasIndex(e => e.IdCliente).IsUnique();
            builder.Property(e => e.IdCliente);

            builder.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(20);

            builder.Property(e => e.FechaRegistro)
            .HasColumnType("DateTime");

            builder.HasOne(p => p.TipoPersona)
            .WithMany(p => p.Clientes)
            .HasForeignKey(p => p.IdTipoPersona);

            builder.HasOne(p => p.Municipio)    
            .WithMany(p => p.Clientes)
            .HasForeignKey(p => p.IdMunicipio);
        }
    }
}