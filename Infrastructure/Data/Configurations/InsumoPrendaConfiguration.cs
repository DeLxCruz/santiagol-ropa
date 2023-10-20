using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class InsumoPrendaConfiguration : IEntityTypeConfiguration<InsumoPrenda>
    {
        public void Configure(EntityTypeBuilder<InsumoPrenda> builder)
        {
            builder.ToTable("InsumoPrenda");

            builder.HasKey(e => new { e.IdInsumo, e.IdPrenda });

            builder.HasOne(p => p.Insumos)
                 .WithMany(p => p.InsumoPrendas)
                 .HasForeignKey(p => p.IdInsumo);

            builder.HasOne(p => p.Prendas)
                    .WithMany(p => p.InsumoPrendas)
                    .HasForeignKey(p => p.IdPrenda);

            builder.Property(e => e.Cantidad)
                    .IsRequired();
        }
    }
}