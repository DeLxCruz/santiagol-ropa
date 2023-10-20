using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class OrdenDto
    {
        public int Id { get; set; }
        public DateOnly Fecha { get; set; }
        public int EmpleadoId { get; set; }
        public int ClienteId { get; set; }
        public int EstadoId { get; set; }
    }
}