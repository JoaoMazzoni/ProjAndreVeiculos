using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using ProjAndreVeiculosAPICliente.Data;
using ProjAndreVeiculosAPIEndereco.Controllers;
using ProjAndreVeiculosAPIEndereco.Services;

namespace ProjAndreVeiculosAPICliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ProjAndreVeiculosAPIClienteContext _context;
        private readonly EnderecosController _enderecoController;
        private readonly EnderecoService _enderecoService;

        public ClientesController(ProjAndreVeiculosAPIClienteContext context, EnderecosController enderecoController, EnderecoService enderecoService)
        {
            _context = context;
            _enderecoController = enderecoController;
            _enderecoService = enderecoService;
        }


        // GET: api/Clientes

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetCliente()
        {
            if (_context.Cliente == null)
            {
                return NotFound();
            }
            return await _context.Cliente.Include(e => e.Endereco).ToListAsync();
        }

        // GET: api/Clientes/5
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(string id)
        {
            if (_context.Cliente == null)
            {
                return NotFound();
            }
            var cliente = await _context.Cliente.Include(e => e.Endereco)
                                                .Where(c => c.Documento == id)
                                                .SingleOrDefaultAsync(c => c.Documento == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(string id, Cliente cliente)
        {
            if (id != cliente.Documento)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Clientes
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente([FromBody] Cliente cliente)
        {
            if (_context.Cliente == null)
            {
                return Problem("Entity set 'ProjAndreVeiculosAPIClienteContext.Cliente' is null.");
            }

            // Obter e preencher as informações do endereço com base no CEP
            var enderecoResult = await _enderecoController.ObterEnderecoPorCepAsync(cliente.Endereco.CEP);
            if (enderecoResult.Value == null)
            {
                return BadRequest("CEP inválido ou não encontrado.");
            }
            cliente.Endereco.Logradouro = enderecoResult.Value.Logradouro;
            cliente.Endereco.Bairro = enderecoResult.Value.Bairro;
            cliente.Endereco.Uf = enderecoResult.Value.Uf;
            cliente.Endereco.Cidade = enderecoResult.Value.Cidade;
            // Preencha outros campos de endereço conforme necessário

            _context.Cliente.Add(cliente);
            _enderecoService.Create(enderecoResult.Value);  

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCliente", new { id = cliente.Documento }, cliente);
        }


        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(string id)
        {
            if (_context.Cliente == null)
            {
                return NotFound();
            }
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(string id)
        {
            return (_context.Cliente?.Any(e => e.Documento == id)).GetValueOrDefault();
        }
    }
}
