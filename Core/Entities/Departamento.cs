using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Departamento : BaseEntity
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int IdPais { get; set; }
        public Pais Paises { get; set; }
        public ICollection<Municipio> Municipios  { get; set; }
    }
}