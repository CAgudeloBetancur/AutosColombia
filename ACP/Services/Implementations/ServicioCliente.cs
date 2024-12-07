using ACP.Models;
using ACP.Repositories.Implementations;
using ACP.Repositories.Interfaces;
using ACP.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ACP.Services.Implementations;

public class ServicioCliente : IServicioCliente
{
    public readonly IClienteRepository _repositorioCliente;

    public ServicioCliente(IClienteRepository repositorioCliente)
    {
        _repositorioCliente = repositorioCliente;
    }

    public async Task ActualizarCliente(Cliente cliente)
    {
        await _repositorioCliente.Actualizar(cliente);
    }

    public async Task CrearCliente(Cliente cliente)
    {
        await _repositorioCliente.Agregar(cliente);
    }

    public async Task<Cliente> ObtenerClientePorId(Guid id)
    {
        return await _repositorioCliente.ObtenerPorId(id);
    }

    public async Task<Cliente> ObtenerPorIdConRelaciones(Guid id)
    {
        return await _repositorioCliente.ObtenerClienteConVehiculos(id);
    }

    public Task<IEnumerable<Cliente>> ObtenerTodosConRelaciones(params Expression<Func<Cliente, object>>[] includes)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Cliente>> ObtenerTodosLosClientes()
    {
        return await _repositorioCliente.ObtenerTodos();
    }

    public async Task<IEnumerable<Cliente>> ClientesFiltrados(Expression<Func<Cliente, bool>> filter)
    {
        return await _repositorioCliente.Filtrados(filter);
    }    

    public async Task<bool> ExisteCliente(Expression<Func<Cliente, bool>> filter)
    {
        return await _repositorioCliente.Existe(filter);
    }

    public async Task<List<TResult>> FiltrarYMapear<TResult>(
        Expression<Func<Cliente, bool>> filtro, Expression<Func<Cliente, TResult>> seleccion
        )
    {
        return await _repositorioCliente.FiltrarYMapear<TResult>(filtro, seleccion);
    }

    public async Task<bool> Eliminar(Guid id)
    {
        return await _repositorioCliente.Eliminar(id);
    }
}
