using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class InsumoProveedor
    {
        [Required]
        public int IdInsumo { get; set; }
        public Insumo Insumos { get; set; }
        [Required]
        public int IdProveedor { get; set; }
        public Proveedor Proveedores { get; set; }
    }
}