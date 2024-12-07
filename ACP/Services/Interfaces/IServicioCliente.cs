using ACP.Models;
using System.Linq.Expressions;

namespace ACP.Services.Interfaces;

public interface IServicioCliente
{
    Task<IEnumerable<Cliente>> ObtenerTodosLosClientes();
    Task<Cliente> ObtenerClientePorId(Guid id);
    Task CrearCliente(Cliente cliente);
    Task ActualizarCliente(Cliente cliente);
    Task<bool> Eliminar(Guid id);
    Task<Cliente> ObtenerPorIdConRelaciones(Guid id);
    Task<IEnumerable<Cliente>> ObtenerTodosConRelaciones(params Expression<Func<Cliente, object>>[] includes);
    Task<IEnumerable<Cliente>> ClientesFiltrados(Expression<Func<Cliente, bool>> filter);
    Task<bool> ExisteCliente(Expression<Func<Cliente, bool>> filter);
    Task<List<TResult>> FiltrarYMapear<TResult>(
            Expression<Func<Cliente, bool>> filtro, Expression<Func<Cliente, TResult>> seleccion
            );
}
