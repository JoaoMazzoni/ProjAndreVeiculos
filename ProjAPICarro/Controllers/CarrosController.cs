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
    public class CarrosController : ControllerBase
    {
        private readonly ProjAPICarroContext _context;

        public CarrosController(ProjAPICarroContext context)
        {
            _context = context;
        }

        // GET: api/Carros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carro>>> GetCarro()
        {
          if (_context.Carro == null)
          {
              return NotFound();
          }
            return await _context.Carro.ToListAsync();
        }

        // GET: api/Carros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carro>> GetCarro(string id)
        {
          if (_context.Carro == null)
          {
              return NotFound();
          }
            var carro = await _context.Carro.FindAsync(id);

            if (carro == null)
            {
                return NotFound();
            }

            return carro;
        }

        // PUT: api/Carros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarro(string id, Carro carro)
        {
            if (id != carro.Placa)
            {
                return BadRequest();
            }

            _context.Entry(carro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarroExists(id))
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

        // POST: api/Carros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Carro>> PostCarro(Carro carro)
        {
          if (_context.Carro == null)
          {
              return Problem("Entity set 'ProjAPICarroContext.Carro'  is null.");
          }
            _context.Carro.Add(carro);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CarroExists(carro.Placa))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCarro", new { id = carro.Placa }, carro);
        }

        // DELETE: api/Carros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarro(string id)
        {
            if (_context.Carro == null)
            {
                return NotFound();
            }
            var carro = await _context.Carro.FindAsync(id);
            if (carro == null)
            {
                return NotFound();
            }

            _context.Carro.Remove(carro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarroExists(string id)
        {
            return (_context.Carro?.Any(e => e.Placa == id)).GetValueOrDefault();
        }
    }
}
