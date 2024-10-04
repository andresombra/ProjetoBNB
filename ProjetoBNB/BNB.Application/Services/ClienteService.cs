using BNB.Application.Interfaces;
using BNB.Domain.Entities;
using BNB.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNB.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task AlterarAsync(Cliente cliente)
        {
            await _clienteRepository.UpdateAsync(cliente);
        }

        public async Task<Cliente> BuscarIdAsync(int id)
        {
            return await _clienteRepository.GetByIdAsync(id);
        }

        public async Task ExcluirAsync(int id)
        {
            await _clienteRepository.DeleteAsync(id);
        }

        public Task IncluirAsync(Cliente cliente)
        {
            return _clienteRepository.AddAsync(cliente);
        }

        public async Task<IEnumerable<Cliente>> ListarTodosClientesAsync()
        {
            return await _clienteRepository.GetAllAsync();
        }
    }
}
