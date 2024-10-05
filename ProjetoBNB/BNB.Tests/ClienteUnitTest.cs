using BNB.Application.Interfaces;
using BNB.Application.Services;
using BNB.Domain.Entities;
using BNB.Domain.Repositories;


namespace BNB.Tests;

public class ClienteUnitTest
{
    private readonly IClienteService _clienteService;
    private readonly IClienteRepository _clienteRepository;

    public ClienteUnitTest(IClienteService clienteService, IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
        _clienteService = clienteService;
    }

    [SetUp]
    public void Setup()
    {

    }

    [Test]
    [TestCase("Joao Teste Tests", "Rua Teste, 999", "email@teste.com", "85987425689")]
    public void ValidarIncluirCliente(string nome, string endereco, string email, string telefone)
    {
        var request = new Cliente() { Nome = nome, Endereco = endereco, Email = email, Telefone = telefone };
        var response = Task.Run(async () => { await _clienteService.IncluirAsync(request); })
    }
}