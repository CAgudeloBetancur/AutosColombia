using ACP.Data;
using ACP.Models;
using ACP.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ACP.Repositories.Implementations;

public class VehiculoRepository : RepositorioGenerico<Vehiculo>, IVehiculoRepository
{
    private readonly ACPDbContext _context;

    public VehiculoRepository(ACPDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Vehiculo> ObtenerPorPlacaConRelaciones(string placa, params Expression<Func<Vehiculo, object>>[] includes)
    {
        IQueryable<Vehiculo> query = _context.Set<Vehiculo>().Where(v => EF.Property<string>(v, "Placa") == placa);
        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        return await query.FirstOrDefaultAsync();
    }
}
