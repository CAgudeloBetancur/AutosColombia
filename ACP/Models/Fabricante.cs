namespace ACP.Models;

public class Fabricante
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public List<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo> { };
}
