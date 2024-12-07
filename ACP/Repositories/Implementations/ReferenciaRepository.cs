using ACP.Data;
using ACP.Models;
using ACP.Repositories.Interfaces;

namespace ACP.Repositories.Implementations;

public class ReferenciaRepository : RepositorioGenerico<Referencia>, IReferenciaRepository
{
    private readonly ACPDbContext _context;

    public ReferenciaRepository(ACPDbContext context) : base(context)
    {
        _context = context;
    }
}
