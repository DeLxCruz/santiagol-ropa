using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class TipoProteccion : BaseEntity
    {
        [Required]
        public string Descripcion { get; set; }
        public ICollection<Prenda> Prendas { get; set; }
    }
}