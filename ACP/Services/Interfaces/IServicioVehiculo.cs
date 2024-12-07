using ACP.Models;
using System.Linq.Expressions;

namespace ACP.Services.Interfaces;

public interface IServicioVehiculo
{
    Task<IEnumerable<Vehiculo>> ObtenerTodosLosVehiculos(); 
    Task<Vehiculo> ObtenerVehiculoPorId(Guid id); 
    Task CrearVehiculo(Vehiculo vehiculo); 
    Task ActualizarVehiculo(Vehiculo vehiculo);
    //Task EliminarVehiculo(Guid id);
    Task<Vehiculo> ObtenerPorIdConRelaciones(Guid id, params Expression<Func<Vehiculo, object>>[] includes);
    Task<IEnumerable<Vehiculo>> ObtenerTodosConRelaciones(params Expression<Func<Vehiculo, object>>[] includes);
    Task<IEnumerable<Vehiculo>> VehiculosFiltrados(Expression<Func<Vehiculo, bool>> filter);
    Task<bool> ExisteVehiculo(Expression<Func<Vehiculo, bool>> filter);
    Task<List<TResult>> FiltrarYMapear<TResult>(
        Expression<Func<Vehiculo, bool>> filtro, Expression<Func<Vehiculo, TResult>> seleccion
        );
    Task<Vehiculo> ObtenerPorPlacaConRelaciones(string placa, params Expression<Func<Vehiculo, object>>[] includes);
    Task<bool> Eliminar(Guid id);
}
