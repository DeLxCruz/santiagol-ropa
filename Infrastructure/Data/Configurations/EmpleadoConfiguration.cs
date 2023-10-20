using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.ToTable("Empleado");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.HasIndex(e => e.IdEmp)
            .IsUnique();

            builder.Property(e => e.Nombre)
                 .IsRequired();

            builder.HasOne(p => p.Cargos)
                 .WithMany(p => p.Empleados)
                 .HasForeignKey(p => p.IdCargo);

            builder.Property(e => e.FechaIngreso)
                    .IsRequired()
                    .HasColumnType("date");

            builder.HasOne(p => p.Municipios)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(p => p.IdMunicipio);
        }
    }
}