using BNB.Application.Interfaces;
using BNB.Domain.Entities;
using BNB.Domain.Response;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;

namespace BNB.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            var clientes = await _clienteService.ListarTodosClientesAsync();
            //return Ok(clientes);

            var resp = new ResponseDto();

            try
            {
               
                resp.Status = true;
                var json = JsonSerializer.Serialize<IEnumerable<Cliente>>(clientes).ToString();
                resp.Data = JsonSerializer.Deserialize<IEnumerable<Cliente>>(json);
                resp.Mensagem = "Lista de todos os clientes.";

                return Ok(resp);
            }
            catch (Exception ex)
            {
                resp.Status = false;
                resp.Mensagem += ex.Message;
                return Ok(resp);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _clienteService.BuscarIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto>> PostCliente(Cliente cliente)
        {
            var resp = new ResponseDto();

            try
            {
               await _clienteService.IncluirAsync(cliente);
               resp.Status = true;
               var json = JsonSerializer.Serialize<Cliente>(cliente).ToString();
               resp.Data = JsonSerializer.Deserialize<Cliente>(json);
               resp.Mensagem = "Cliente gravado com sucesso."; 
                
                return CreatedAtAction(nameof(PostCliente), resp);
            }
            catch (Exception ex)
            {
                resp.Status = false;
                resp.Mensagem += ex.Message;
                return Ok(resp); 
            }

            
        }

        [HttpPut]
        public async Task<IActionResult> PutCliente(Cliente cliente)
        {
            await _clienteService.AlterarAsync(cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            await _clienteService.ExcluirAsync(id);
            return NoContent();
        }
    }
}
