using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;
public class Cliente : BaseEntity
{
    [Required]
    public int IdCliente { get; set; }
    public string Nombre { get; set; }
    [Required]
    public int IdTipoPersona { get; set; }
    public TipoPersona TipoPersonas { get; set; }
    public DateOnly FechaRegistro { get; set; }
    [Required]
    public int IdMunicipio { get; set; }
    public Municipio Municipios { get; set; }
    public ICollection<Venta> Ventas { get; set; }
    public ICollection<Orden> Ordenes { get; set; }
}