using ACP.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace ACP.Services.Interfaces
{
    public interface IServicioFabricante
    {
        Task<IEnumerable<SelectListItem>> Mapear(Expression<Func<Fabricante, SelectListItem>> map);
        Task<IEnumerable<Fabricante>> ObtenerTodosLosFabricantes();
    }
}
