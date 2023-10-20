using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Proveedor : BaseEntity
    {
        [Required]
        public int NitProveedor { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int IdTipoPersona { get; set; }
        public TipoPersona TipoPersonas { get; set; }
        [Required]
        public int IdMunicipio { get; set; }
        public Municipio Municipios { get; set; }
        public ICollection<InsumoProveedor> InsumoProveedores { get; set; }
    }
}