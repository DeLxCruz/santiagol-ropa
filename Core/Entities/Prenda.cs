using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Prenda : BaseEntity
    {
        [Required]
        public int IdPrenda { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int ValorUnitCop { get; set; }
        [Required]
        public int ValorUnitUsd { get; set; }
        [Required]
        public int IdEstado { get; set; }
        public Estado Estados { get; set; }
        [Required]
        public int IdTipProteccion { get; set; }
        public TipoProteccion TipoProtecciones { get; set; }
        [Required]
        public int IdGenero { get; set; }
        public ICollection<InsumoPrenda> InsumoPrendas { get; set; }
        public ICollection<Inventario> Inventario { get; set; }
    }
}