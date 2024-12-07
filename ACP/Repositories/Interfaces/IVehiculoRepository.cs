using ACP.Models;
using System.Linq.Expressions;

namespace ACP.Repositories.Interfaces;

public interface IVehiculoRepository : IRepositorioGenerico<Vehiculo>
{
    Task<Vehiculo> ObtenerPorPlacaConRelaciones(string placa, params Expression<Func<Vehiculo, object>>[] includes);
}
