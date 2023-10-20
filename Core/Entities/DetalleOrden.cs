using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class DetalleOrden : BaseEntity
    {
        [Required]
        public int IdOrden { get; set; }
        public Orden Ordenes { get; set; }
        [Required]
        public int IdPrenda { get; set; }
        public Prenda Prendas { get; set; }
        [Required]
        public int CantidadPorducir { get; set; }
        [Required]
        public int IdColor { get; set; }
        public Color Colores { get; set; }
        [Required]
        public int CantidadProducida { get; set; }
        [Required]
        public int IdEstado { get; set; }
        public Estado Estados { get; set; }
    }
}