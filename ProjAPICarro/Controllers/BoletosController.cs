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
    public class BoletosController : ControllerBase
    {
        private readonly ProjAPICarroContext _context;

        public BoletosController(ProjAPICarroContext context)
        {
            _context = context;
        }

        // GET: api/Boletos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Boleto>>> GetBoleto()
        {
          if (_context.Boleto == null)
          {
              return NotFound();
          }
            return await _context.Boleto.ToListAsync();
        }

        // GET: api/Boletos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Boleto>> GetBoleto(int id)
        {
          if (_context.Boleto == null)
          {
              return NotFound();
          }
            var boleto = await _context.Boleto.FindAsync(id);

            if (boleto == null)
            {
                return NotFound();
            }

            return boleto;
        }

        // PUT: api/Boletos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoleto(int id, Boleto boleto)
        {
            if (id != boleto.Id)
            {
                return BadRequest();
            }

            _context.Entry(boleto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoletoExists(id))
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

        // POST: api/Boletos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Boleto>> PostBoleto(Boleto boleto)
        {
          if (_context.Boleto == null)
          {
              return Problem("Entity set 'ProjAPICarroContext.Boleto'  is null.");
          }
            _context.Boleto.Add(boleto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoleto", new { id = boleto.Id }, boleto);
        }

        // DELETE: api/Boletos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoleto(int id)
        {
            if (_context.Boleto == null)
            {
                return NotFound();
            }
            var boleto = await _context.Boleto.FindAsync(id);
            if (boleto == null)
            {
                return NotFound();
            }

            _context.Boleto.Remove(boleto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BoletoExists(int id)
        {
            return (_context.Boleto?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
