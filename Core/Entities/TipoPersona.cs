using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class TipoPersona : BaseEntity
    {
        [Required]
        public string Descripcion { get; set; }
        public ICollection<Proveedor> Proveedores { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
    }
}