using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class InventarioTalla : BaseEntity
    {
        [Required]
        public int IdInv { get; set; }
        public Inventario Inventarios { get; set; }
        [Required]
        public int IdTalla { get; set; }
        public Talla Tallas { get; set; }
        [Required]
        public int Cantidad { get; set; }
    }
}