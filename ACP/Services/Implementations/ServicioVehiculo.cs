using ACP.Models;
using ACP.Repositories.Implementations;
using ACP.Repositories.Interfaces;
using ACP.Services.Interfaces;
using System.Linq.Expressions;

namespace ACP.Services.Implementations;

public class ServicioVehiculo : IServicioVehiculo
{
    private readonly IVehiculoRepository _repositorioVehiculo;

    public ServicioVehiculo(IVehiculoRepository repositorioVehiculo)
    {
        _repositorioVehiculo = repositorioVehiculo;
    }

    public async Task ActualizarVehiculo(Vehiculo vehiculo)
    {
        await _repositorioVehiculo.Actualizar(vehiculo);
    }

    public async Task<IEnumerable<Vehiculo>> VehiculosFiltrados(Expression<Func<Vehiculo, bool>> filter)
    {
        return await _repositorioVehiculo.Filtrados(filter);
    }

    public async Task CrearVehiculo(Vehiculo vehiculo)
    {
        await _repositorioVehiculo.Agregar(vehiculo);
    }

    /*public async Task EliminarVehiculo(Guid id)
    {
        await _repositorioVehiculo.Eliminar(id);
    }*/

    public async Task<Vehiculo> ObtenerPorIdConRelaciones(
        Guid id, params Expression<Func<Vehiculo, object>>[] includes
        )
    {
        return await _repositorioVehiculo.ObtenerPorIdConRelaciones(
            id, 
            includes
            );
    }

    public async Task<IEnumerable<Vehiculo>> ObtenerTodosConRelaciones(
        params Expression<Func<Vehiculo, object>>[] includes
        )
    {
        return await _repositorioVehiculo.ObtenerTodosConRelaciones(
           v => v.Fabricante,
           v => v.Color,
           v => v.Referencia
           );
    }

    public async Task<IEnumerable<Vehiculo>> ObtenerTodosLosVehiculos()
    {
        return await _repositorioVehiculo.ObtenerTodos();
    }

    public async Task<Vehiculo> ObtenerVehiculoPorId(Guid id)
    {
        return await _repositorioVehiculo.ObtenerPorId(id);
    }

    public async Task<bool> ExisteVehiculo(Expression<Func<Vehiculo, bool>> filter)
    {
        return await _repositorioVehiculo.Existe(filter);
    }

    public async Task<List<TResult>> FiltrarYMapear<TResult>(
        Expression<Func<Vehiculo, bool>> filtro, Expression<Func<Vehiculo, TResult>> seleccion
        )
    {
        return await _repositorioVehiculo.FiltrarYMapear<TResult>(filtro, seleccion);
    }

    public async Task<Vehiculo> ObtenerPorPlacaConRelaciones(string placa, params Expression<Func<Vehiculo, object>>[] includes)
    {
        return await _repositorioVehiculo.ObtenerPorPlacaConRelaciones(placa, includes);
    }

    public async Task<bool> Eliminar(Guid id)
    {
        return await _repositorioVehiculo.Eliminar(id);
    }
}
