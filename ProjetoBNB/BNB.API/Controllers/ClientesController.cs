using Azure;
using BNB.Application.Interfaces;
using BNB.Domain.Entities;
using BNB.Domain.Response;
using BNB.Domain.Validators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
            var resp = new ResponseDto();
            try
            {
                var clientes = await _clienteService.ListarTodosClientesAsync();
                resp.Status = true;
                resp.Data = clientes;
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
               var validator = new ClienteValidator();
               var result = validator.Validate(cliente);
               if (!result.IsValid)
               {
                  // Captura as mensagens de erro e junta-as em uma única string
                  resp.Mensagem = string.Join("; ", result.Errors.Select(e => e.ErrorMessage));
                  resp.Status = false;  // Definindo Status como falso devido a falha na validação

                  return BadRequest(resp);
               }

               await _clienteService.IncluirAsync(cliente);
               resp.Status = true;
               resp.Data = cliente;
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
