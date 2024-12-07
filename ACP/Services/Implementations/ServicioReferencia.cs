using ACP.Models;
using ACP.Repositories.Interfaces;
using ACP.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace ACP.Services.Implementations
{
    public class ServicioReferencia : IServicioReferencia
    {
        private readonly IReferenciaRepository _referenciaRepository;

        public ServicioReferencia(IReferenciaRepository referenciaRepository)
        {
            _referenciaRepository = referenciaRepository;
        }

        public async Task<List<TResult>> FiltrarYMapear<TResult>(
            Expression<Func<Referencia, bool>> filtro, Expression<Func<Referencia, TResult>> seleccion
            )
        {
            return await _referenciaRepository.FiltrarYMapear<TResult>(filtro, seleccion);
        }

        public async Task<IEnumerable<SelectListItem>> Mapear(Expression<Func<Referencia, SelectListItem>> map)
        {
            return await _referenciaRepository.Mapear(map);
        }
    }
}
