using ACP.Data;
using ACP.Models;
using ACP.Repositories.Interfaces;

namespace ACP.Repositories.Implementations;

public class FabricanteRepository : RepositorioGenerico<Fabricante>, IFabricanteRepository
{
    private readonly ACPDbContext _context;

    public FabricanteRepository(ACPDbContext context) : base(context)
    {
        _context = context;
    }
}
