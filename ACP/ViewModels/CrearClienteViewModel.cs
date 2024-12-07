using Microsoft.AspNetCore.Mvc.Rendering;

namespace ACP.ViewModels;

public class CrearClienteViewModel
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Documento { get; set; }
    public string Telefono { get; set; }
    public string Correo { get; set; }
    public List<string> VehiculosSeleccionados { get; set; } = new List<string>();
}
