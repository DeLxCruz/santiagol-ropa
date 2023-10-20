using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class Inventario
    {
        public int CodInventario { get; set; }
        public int PrendaId { get; set; }
        public double ValorVentaCOP  { get; set; }
        public double ValorVentaUSD { get; set; }
    }
}