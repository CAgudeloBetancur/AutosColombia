using ACP.Data;
using ACP.Models;
using ACP.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ACP.Repositories.Implementations;

public class ClienteRepository : RepositorioGenerico<Cliente>, IClienteRepository
{
    private readonly ACPDbContext _context;

    public ClienteRepository(ACPDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Cliente> ObtenerClienteConVehiculos(Guid clienteId)
    {
        return await _context
            .Clientes
            .Include(c => c.Vehiculos)
            .ThenInclude(v => v.Color)
            .Include(c => c.Vehiculos)
            .ThenInclude(v => v.Referencia)
            .FirstOrDefaultAsync(c => c.Id == clienteId);
    }

}
