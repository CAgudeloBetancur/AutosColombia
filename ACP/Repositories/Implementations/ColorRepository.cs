using ACP.Data;
using ACP.Models;
using ACP.Repositories.Interfaces;

namespace ACP.Repositories.Implementations;

public class ColorRepository : RepositorioGenerico<Color>, IColorRepository
{
    private readonly ACPDbContext _context;

    public ColorRepository(ACPDbContext context) : base(context)
    {
        _context = context;
    }
}
