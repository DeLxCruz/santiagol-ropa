using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Venta : BaseEntity
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
        public int IdFormaPago { get; set; }
        public FormaPago FormasPago { get; set; }
        public ICollection<DetalleVenta> DetalleVentas { get; set; }
    }
}