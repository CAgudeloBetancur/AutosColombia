using ACP.Models;
using System.Linq.Expressions;

namespace ACP.Repositories.Interfaces;

public interface IClienteRepository : IRepositorioGenerico<Cliente>
{
    Task<Cliente> ObtenerClienteConVehiculos(Guid clienteId);
}
