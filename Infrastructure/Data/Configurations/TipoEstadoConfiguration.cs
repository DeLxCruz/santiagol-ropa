using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class TipoEstadoConfiguration : IEntityTypeConfiguration<TipoEstado>
    {
        public void Configure(EntityTypeBuilder<TipoEstado> builder)
        {
            builder.ToTable("TipoEstado");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.Descripcion)
                 .IsRequired();


            
        }
    }
}