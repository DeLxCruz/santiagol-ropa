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
        public int IdTipoProteccion { get; set; }
        public TipoProteccion TipoProtecciones { get; set; }
        [Required]
        public int IdGenero { get; set; }
        public Genero Generos { get; set; }
        public ICollection<InsumoPrenda> InsumoPrendas { get; set; }
        public ICollection<Inventario> Inventarios { get; set; }
        public ICollection<DetalleOrden> DetalleOrdenes { get; set; }


    }
}