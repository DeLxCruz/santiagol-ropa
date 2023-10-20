using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Color : BaseEntity
    {
        public string Descripcion { get; set; }
        public ICollection<DetalleOrden> DetalleOrdenes { get; set; }
    }
}