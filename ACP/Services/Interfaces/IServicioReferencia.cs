using ACP.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace ACP.Services.Interfaces
{
    public interface IServicioReferencia
    {
        Task<IEnumerable<SelectListItem>> Mapear(Expression<Func<Referencia, SelectListItem>> map);
        Task<List<TResult>> FiltrarYMapear<TResult>(
            Expression<Func<Referencia, bool>> filtro, Expression<Func<Referencia, TResult>> seleccion
            );
    }
}
