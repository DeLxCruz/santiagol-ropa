using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            builder.ToTable("Proveedor");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.HasIndex(e => e.NitProveedor)
                   .IsUnique();

            builder.Property(e => e.NitProveedor)
                     .IsRequired();

            builder.Property(e => e.Nombre)
                     .IsRequired();

            builder.HasOne(p => p.TipoPersonas)
                 .WithMany(p => p.Proveedores)
                 .HasForeignKey(p => p.IdTipoPersona);

            builder.HasOne(p => p.Municipios)
                 .WithMany(p => p.Proveedores)
                 .HasForeignKey(p => p.IdMunicipio);
        }
    }
}