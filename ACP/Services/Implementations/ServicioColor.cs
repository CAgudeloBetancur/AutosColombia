using ACP.Models;
using ACP.Repositories.Interfaces;
using ACP.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace ACP.Services.Implementations
{
    public class ServicioColor : IServicioColor
    {
        private readonly IColorRepository _colorRepository;

        public ServicioColor(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public async Task<IEnumerable<SelectListItem>> Mapear(Expression<Func<Color, SelectListItem>> map)
        {
            return await _colorRepository.Mapear(map);
        }
    }
}
