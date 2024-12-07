using Microsoft.AspNetCore.Mvc.Rendering;

namespace ACP.ViewModels;

public class CrearVehiculoViewModel
{
    public string Placa { get; set; }
    public string Modelo { get; set; }
    public Guid FabricanteId { get; set; }
    public Guid ColorId { get; set; }
    public Guid ReferenciaId { get; set; }
    public List<string> ClientesSeleccionados { get; set; } = new List<string>();
    public SelectList? Fabricantes { get; set; }
    public SelectList? Colores { get; set; }
    public SelectList? Modelos { get; set; }
    public SelectList? Referencias { get; set; }
}
