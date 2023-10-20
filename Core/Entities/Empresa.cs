using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Empresa : BaseEntity
    {
        [Required]
        public int Nit { get; set; }
        public string RazonSocial { get; set; }
        [Required]
        public string RepresentanteLegal { get; set; }
        [Required]
        public DateOnly FechaCreacion { get; set; }
    }
}