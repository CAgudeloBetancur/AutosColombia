using ACP.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace ACP.Services.Interfaces
{
    public interface IServicioColor
    {
        Task<IEnumerable<SelectListItem>> Mapear(Expression<Func<Color, SelectListItem>> map);
    }
}
