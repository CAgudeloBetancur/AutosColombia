namespace ACP.Models;

public class Referencia
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public Guid FabricanteId { get; set; }
    public Fabricante Fabricante { get; set; }
    public List<Vehiculo> Vehiculos { get; set; }
}
