using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Municipio : BaseEntity
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int IdDep { get; set; }
        public Departamento Departamentos { get; set; }
        public ICollection<Empresa> Empresas { get; set; }
        public ICollection<Empleado> Empleados { get; set; }
    }
}