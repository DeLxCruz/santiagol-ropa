using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Insumo : BaseEntity
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int ValorUnit { get; set; }
        [Required]
        public int StockMin { get; set; }
        [Required]
        public int StockMax { get; set; }
        public ICollection<InsumoProveedor> InsumoProveedores { get; set; }
        public ICollection<InsumoPrenda> InsumoPrendas { get; set; }
    }
}