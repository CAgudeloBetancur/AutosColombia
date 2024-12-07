using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ACP.Models;

[Index(nameof(Placa), IsUnique = true)]
public class Vehiculo
{
    public Guid Id { get; set; }
    [StringLength(6)]
    public string Placa { get; set; }
    public string Modelo { get; set; }
    public Guid FabricanteId { get; set; }
    public Fabricante Fabricante { get; set; }
    public Guid ColorId { get; set; }
    public Color Color { get; set; }
    public Guid ReferenciaId { get; set; }
    public Referencia Referencia { get; set; }
    public List<Cliente> Clientes { get; set; } = new List<Cliente>();
}
