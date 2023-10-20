using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class TipoPersonaConfiguration : IEntityTypeConfiguration<TipoPersona>
    {
        public void Configure(EntityTypeBuilder<TipoPersona> builder)
        {
            builder.ToTable("TipoPersona");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.Nombre)
                  .IsRequired();
        }
    }
}