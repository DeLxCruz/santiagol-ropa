using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Pais : BaseEntity
    {
        [Required]
        public string Nombre { get; set; }
        public ICollection<Departamento> Departamentos { get; set; }
    }
}