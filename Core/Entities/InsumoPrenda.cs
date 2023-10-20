using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class InsumoPrenda
    {
        [Required]
        public int IdInsumo { get; set; }
        public Insumo Insumos { get; set; }
        [Required]
        public int IdPrenda { get; set; }
        public Prenda Prendas { get; set; }
        [Required]
        public int Cantidad { get; set; }   
    }
}