using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace ACP.Repositories.Interfaces;

public interface IRepositorioGenerico<T> where T : class
{
    Task<IEnumerable<T>> ObtenerTodos();
    Task<T> ObtenerPorId(Guid id);
    Task Agregar(T entidad);
    Task Actualizar(T entidad);
    Task<bool> Eliminar(Guid id);
    Task<IEnumerable<T>> ObtenerTodosConRelaciones(params Expression<Func<T, object>>[] includes);
    Task<T> ObtenerPorIdConRelaciones(Guid id, params Expression<Func<T, object>>[] includes);
    Task<IEnumerable<T>> Filtrados(Expression<Func<T, bool>> filter);
    Task<IEnumerable<SelectListItem>> Mapear(Expression<Func<T, SelectListItem>> map);
    Task<bool> Existe(Expression<Func<T, bool>> filter);
    Task<List<TResult>> FiltrarYMapear<TResult>(
        Expression<Func<T, bool>> filtro, Expression<Func<T, TResult>> seleccion
        );
}
