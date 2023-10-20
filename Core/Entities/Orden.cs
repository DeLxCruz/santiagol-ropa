using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Orden : BaseEntity
    {
        [Required]
        public DateOnly Fecha { get; set; }
        [Required]
        public int IdEmpleado { get; set; }
        public Empleado Empleados { get; set; }
        [Required]
        public int IdCliente { get; set; }
        public Cliente Clientes { get; set; }
        [Required]
        public int IdEstado { get; set; }
        public Estado Estados { get; set; }
        public ICollection<DetalleOrden> DetalleOrdenes { get; set; }
        public ICollection<Inventario> Inventarios { get; set; }

    }
}