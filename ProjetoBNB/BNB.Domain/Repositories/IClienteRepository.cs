using BNB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNB.Domain.Repositories
{
    public interface IClienteRepository
    {
        Task<Cliente> GetByIdAsync(int id);
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task AddAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(int id);
    }
}
