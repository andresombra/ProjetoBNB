using BNB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNB.Application.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> ListarTodosClientesAsync();
        Task<Cliente> BuscarIdAsync(int id);
        Task IncluirAsync(Cliente cliente);
        Task AlterarAsync(Cliente cliente);
        Task ExcluirAsync(int id);
    }
}
