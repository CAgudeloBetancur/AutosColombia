namespace ACP.ViewModels;

public class DetailsClienteViewModel
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public List<VehiculoInfo> Vehiculos { get; set; }

    public class VehiculoInfo
    {
        public string Placa { get; set; }
        public string Referencia { get; set; }
        public string Color { get; set; }
    }
}