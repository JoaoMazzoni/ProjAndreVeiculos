using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using ProjAndreVeiculosAPICondutor.Data;
using ProjAndreVeiculosAPIEndereco.Controllers;

namespace ProjAndreVeiculosAPICondutor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CondutoresController : ControllerBase
    {
        private readonly ProjAndreVeiculosAPICondutorContext _context;
        private readonly EnderecosController _enderecoController;

        public CondutoresController(ProjAndreVeiculosAPICondutorContext context, EnderecosController enderecoController)
        {
            _context = context; 
            _enderecoController = enderecoController;
        }

        // GET: api/Condutores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Condutor>>> GetCondutor()
        {
          if (_context.Condutor == null)
          {
              return NotFound();
          }
            return await _context.Condutor.Include(c => c.CNH).ToListAsync();
        }

        // GET: api/Condutores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Condutor>> GetCondutor(string documento)
        {
          if (_context.Condutor == null)
          {
              return NotFound();
          }
            var condutor = await _context.Condutor.Include(c => c.CNH).Where(d => d.Documento == documento).SingleOrDefaultAsync(d => d.Documento == documento);
             

            if (condutor == null)
            {
                return NotFound();
            }

            return condutor;
        }

        // PUT: api/Condutores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCondutor(string id, Condutor condutor)
        {
            if (id != condutor.Documento)
            {
                return BadRequest();
            }

            _context.Entry(condutor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CondutorExists(id))
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

        // POST: api/Condutores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Condutor>> PostCondutor(Condutor condutor)
        {
          if (_context.Condutor == null)
          {
              return Problem("Entity set 'ProjAndreVeiculosAPICondutorContext.Condutor'  is null.");
          }

            // Obter e preencher as informações do endereço com base no CEP
            var enderecoResult = await _enderecoController.ObterEnderecoPorCepAsync(condutor.Endereco.CEP);
            if (enderecoResult.Value == null)
            {
                return BadRequest("CEP inválido ou não encontrado.");
            }
            
            condutor.Endereco.Logradouro = enderecoResult.Value.Logradouro;
            condutor.Endereco.Bairro = enderecoResult.Value.Bairro;
            condutor.Endereco.Uf = enderecoResult.Value.Uf;
            condutor.Endereco.Cidade = enderecoResult.Value.Cidade;
            // Preencha outros campos de endereço conforme necessário

            _context.Condutor.Add(condutor);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CondutorExists(condutor.Documento))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCondutor", new { id = condutor.Documento }, condutor);
        }

        // DELETE: api/Condutores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCondutor(string id)
        {
            if (_context.Condutor == null)
            {
                return NotFound();
            }
            var condutor = await _context.Condutor.FindAsync(id);
            if (condutor == null)
            {
                return NotFound();
            }

            _context.Condutor.Remove(condutor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CondutorExists(string id)
        {
            return (_context.Condutor?.Any(e => e.Documento == id)).GetValueOrDefault();
        }
    }
}
