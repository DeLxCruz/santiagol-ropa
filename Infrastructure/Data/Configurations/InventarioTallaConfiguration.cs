using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class InventarioTallaConfiguration : IEntityTypeConfiguration<InventarioTalla>
    {
        public void Configure(EntityTypeBuilder<InventarioTalla> builder)
        {
            builder.ToTable("InventarioTalla");

            builder.HasKey(e => new { e.Id, e.IdInv });
            builder.HasKey(e => new { e.Id, e.IdTalla });

            builder.Property(e => e.Cantidad)
                    .IsRequired()
                    .HasColumnType("int");
        }
    }
}