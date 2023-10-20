using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class DetalleVenta : BaseEntity
    {
        [Required]
        public int IdVenta { get; set; }
        public Venta Ventas { get; set; }
        [Required]
        public int IdProducto { get; set; }
        public Inventario Inventarios { get; set; }
        [Required]
        public int IdTalla { get; set; }
        public Talla Tallas { get; set; }
        public int Cantidad { get; set; }
        [Required]
        public double ValorUnit { get; set; }
        
    }
}