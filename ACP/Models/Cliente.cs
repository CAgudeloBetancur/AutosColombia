using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace ACP.Models;

[Index(nameof(Documento),nameof(Correo), IsUnique = true)]
public class Cliente
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Documento { get; set; }
    public string Telefono { get; set; }
    public string Correo { get; set; }
    public List<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}
