using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Empleado : BaseEntity
    {
        [Required]
        public int IdEmpleado { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int IdCargo { get; set; }
        public Cargo Cargos { get; set; }
        [Required]
        public DateOnly FechaIngreso { get; set; }
        [Required]
        public int IdMunicipio { get; set; }
        public Municipio Municipios { get; set; }
        public ICollection<Venta> Ventas { get; set; }
    }
}