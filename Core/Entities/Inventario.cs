using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Inventario : BaseEntity
    {
        [Required]
        public int CodInv { get; set; }
        [Required]
        public int IdPrenda { get; set; }
        public Prenda Prendas { get; set; }
        [Required]
        public double ValorVtaCop { get; set; }
        [Required]
        public double ValorVtaUsd { get; set; }
        public ICollection<InventarioTalla> InventarioTallas { get; set; }
        public ICollection<DetalleVenta> DetalleVentas { get; set; }
    }
}