using ACP.Models;
using ACP.Repositories.Interfaces;
using ACP.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace ACP.Services.Implementations
{
    public class ServicioFabricante : IServicioFabricante
    {
        private readonly IFabricanteRepository _fabricanteRepository;

        public ServicioFabricante(IFabricanteRepository fabricanteRepository)
        {
            _fabricanteRepository = fabricanteRepository;
        }

        public async Task<IEnumerable<SelectListItem>> Mapear(Expression<Func<Fabricante, SelectListItem>> map)
        {
            return await _fabricanteRepository.Mapear(map);
        }

        public async Task<IEnumerable<Fabricante>> ObtenerTodosLosFabricantes()
        {
            return await _fabricanteRepository.ObtenerTodos();
        }
    }
}
