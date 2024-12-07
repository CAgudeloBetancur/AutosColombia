using ACP.Data;
using ACP.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace ACP.Repositories.Implementations;

public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
{
    private readonly ACPDbContext _context;

    public RepositorioGenerico(ACPDbContext context)
    {
        _context = context;
    }

    public async Task Actualizar(T entidad)
    {
        _context.Set<T>().Update(entidad);
        await _context.SaveChangesAsync();
    }

    public async Task Agregar(T entidad)
    {
        await _context.Set<T>().AddAsync(entidad);
        await _context.SaveChangesAsync();
    }

    public async Task<T> ObtenerPorId(Guid id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> ObtenerTodos()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> ObtenerPorIdConRelaciones(Guid id, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _context.Set<T>().Where(e => EF.Property<Guid>(e, "Id") == id);
        foreach(var include in includes)
        {
            query = query.Include(include);
        }
        return await query.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<T>> ObtenerTodosConRelaciones(params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _context.Set<T>();
        foreach(var include in includes)
        {
            query = query.Include(include);
        }
        return await query.ToListAsync();
    }

    public async Task<IEnumerable<T>> Filtrados(Expression<Func<T, bool>> filter)
    {
        return await _context.Set<T>().Where(filter).ToListAsync();
    }

    public async Task<IEnumerable<SelectListItem>> Mapear(Expression<Func<T, SelectListItem>> map)
    {
        return await _context.Set<T>().Select(map).ToListAsync();
    }

    public async Task<bool> Existe(Expression<Func<T, bool>> filter)
    {
        return await _context.Set<T>().AnyAsync(filter);
    }

    public async Task<List<TResult>> FiltrarYMapear<TResult>(
        Expression<Func<T, bool>> filtro, Expression<Func<T, TResult>> seleccion
        )
    {
        return await _context.Set<T>()
            .Where(filtro)
            .Select(seleccion)
            .ToListAsync();
    }

    public async Task<bool> Eliminar(Guid id)
    {
        var entidad = await ObtenerPorId(id);
        
        if (entidad == null) return false;

        _context.Set<T>().Remove(entidad);

        await _context.SaveChangesAsync();

        return true;
    }

}
