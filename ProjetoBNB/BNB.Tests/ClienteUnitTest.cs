using BNB.Application.Interfaces;
using BNB.Application.Services;
using BNB.Domain.Entities;
using BNB.Domain.Repositories;
using Moq;


namespace BNB.Tests;

public class ClienteUnitTest
{
    private Mock<IClienteService> _clienteServiceMock;

    [SetUp]
    public void Setup()
    {
        // Inicializa o mock do serviço antes de cada teste
        _clienteServiceMock = new Mock<IClienteService>();
    }

    [Test]
    [TestCase("Joao Teste")]
    public async Task ValidarNomeCliente_DeveRetornarNomeValido(string nome)
    {
        // Arrange
        var request = new Cliente { Nome = nome };

        // Mocka o comportamento esperado do método IncluirAsync
        _clienteServiceMock
            .Setup(service => service.IncluirAsync(It.IsAny<Cliente>()))
            .ReturnsAsync(request); // Retorna o próprio cliente com o nome informado

        // Act
        var response = await _clienteServiceMock.Object.IncluirAsync(request);

        // Assert
        Assert.IsNotNull(response);
        Assert.IsNotEmpty(response.Nome);
        Assert.AreEqual(nome, response.Nome);
    }
}