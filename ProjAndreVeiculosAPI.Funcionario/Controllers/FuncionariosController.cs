using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using ProjAndreVeiculosAPIEndereco.Controllers;
using ProjAndreVeiculosAPIFuncionario.Data;

namespace ProjAndreVeiculosAPIFuncionario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly ProjAndreVeiculosAPIFuncionarioContext _context;
        private readonly EnderecosController _enderecoController;

        public FuncionariosController(ProjAndreVeiculosAPIFuncionarioContext context, EnderecosController enderecoController)
        {
            _context = context;
            _enderecoController = enderecoController;
        }

        // GET: api/Funcionarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funcionario>>> GetFuncionario()
        {
          if (_context.Funcionario == null)
          {
              return NotFound();
          }
            return await _context.Funcionario.Include(c => c.Cargo).Include(e => e.Endereco).ToListAsync();
        }

        // GET: api/Funcionarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Funcionario>> GetFuncionario(string id)
        {
          if (_context.Funcionario == null)
          {
              return NotFound();
          }
            var funcionario = await _context.Funcionario.Include(c => c.Cargo).Include(e => e.Endereco).Where(f => f.Documento == id).SingleOrDefaultAsync(f => f.Documento == id);

            if (funcionario == null)
            {
                return NotFound();
            }

            return funcionario;
        }

        // PUT: api/Funcionarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuncionario(string id, Funcionario funcionario)
        {
            if (id != funcionario.Documento)
            {
                return BadRequest();
            }

            _context.Entry(funcionario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncionarioExists(id))
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

        // POST: api/Funcionarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Funcionario>> PostFuncionario(Funcionario funcionario)
        {
            if (_context.Funcionario == null)
            {
                return Problem("Entity set 'ProjAndreVeiculosAPIFuncionarioContext.Funcionario' is null.");
            }

            // Obter e preencher as informações do endereço com base no CEP
            var enderecoResult = await _enderecoController.ObterEnderecoPorCepAsync(funcionario.Endereco.CEP);
            if (enderecoResult.Value == null)
            {
                return BadRequest("CEP inválido ou não encontrado.");
            }
            funcionario.Endereco.Logradouro = enderecoResult.Value.Logradouro;
            funcionario.Endereco.Bairro = enderecoResult.Value.Bairro;
            funcionario.Endereco.Uf = enderecoResult.Value.Uf;
            funcionario.Endereco.Cidade = enderecoResult.Value.Cidade;
            funcionario.Endereco.TipoLogradouro = enderecoResult.Value.TipoLogradouro;
            // Preencha outros campos de endereço conforme necessário

            _context.Funcionario.Add(funcionario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FuncionarioExists(funcionario.Documento))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFuncionario", new { id = funcionario.Documento }, funcionario);
        }

        // DELETE: api/Funcionarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncionario(string id)
        {
            if (_context.Funcionario == null)
            {
                return NotFound();
            }
            var funcionario = await _context.Funcionario.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }

            _context.Funcionario.Remove(funcionario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FuncionarioExists(string id)
        {
            return (_context.Funcionario?.Any(e => e.Documento == id)).GetValueOrDefault();
        }
    }
}
