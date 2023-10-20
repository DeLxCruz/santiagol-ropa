using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Estado : BaseEntity
    {
        public string Descripcion { get; set; }
        [Required]
        public int IdTipoEstado { get; set; }
        public TipoEstado TipoEstados { get; set; }
        public ICollection<DetalleOrden> DetalleOrdenes { get; set; }
    }
}