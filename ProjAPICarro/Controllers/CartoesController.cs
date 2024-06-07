using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using ProjAPICarro.Data;

namespace ProjAPICarro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartoesController : ControllerBase
    {
        private readonly ProjAPICarroContext _context;

        public CartoesController(ProjAPICarroContext context)
        {
            _context = context;
        }

        // GET: api/Cartoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cartao>>> GetCartao()
        {
          if (_context.Cartao == null)
          {
              return NotFound();
          }
            return await _context.Cartao.ToListAsync();
        }

        // GET: api/Cartoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cartao>> GetCartao(string id)
        {
          if (_context.Cartao == null)
          {
              return NotFound();
          }
            var cartao = await _context.Cartao.FindAsync(id);

            if (cartao == null)
            {
                return NotFound();
            }

            return cartao;
        }

        // PUT: api/Cartoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartao(string id, Cartao cartao)
        {
            if (id != cartao.NumeroCartao)
            {
                return BadRequest();
            }

            _context.Entry(cartao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartaoExists(id))
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

        // POST: api/Cartoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cartao>> PostCartao(Cartao cartao)
        {
          if (_context.Cartao == null)
          {
              return Problem("Entity set 'ProjAPICarroContext.Cartao'  is null.");
          }
            _context.Cartao.Add(cartao);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CartaoExists(cartao.NumeroCartao))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCartao", new { id = cartao.NumeroCartao }, cartao);
        }

        // DELETE: api/Cartoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartao(string id)
        {
            if (_context.Cartao == null)
            {
                return NotFound();
            }
            var cartao = await _context.Cartao.FindAsync(id);
            if (cartao == null)
            {
                return NotFound();
            }

            _context.Cartao.Remove(cartao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CartaoExists(string id)
        {
            return (_context.Cartao?.Any(e => e.NumeroCartao == id)).GetValueOrDefault();
        }
    }
}
