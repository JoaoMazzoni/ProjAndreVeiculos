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
    public class TiposPixController : ControllerBase
    {
        private readonly ProjAPICarroContext _context;

        public TiposPixController(ProjAPICarroContext context)
        {
            _context = context;
        }

        // GET: api/TiposPix
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoPix>>> GetTipoPix()
        {
          if (_context.TipoPix == null)
          {
              return NotFound();
          }
            return await _context.TipoPix.ToListAsync();
        }

        // GET: api/TiposPix/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoPix>> GetTipoPix(int id)
        {
          if (_context.TipoPix == null)
          {
              return NotFound();
          }
            var tipoPix = await _context.TipoPix.FindAsync(id);

            if (tipoPix == null)
            {
                return NotFound();
            }

            return tipoPix;
        }

        // PUT: api/TiposPix/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoPix(int id, TipoPix tipoPix)
        {
            if (id != tipoPix.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoPix).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoPixExists(id))
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

        // POST: api/TiposPix
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoPix>> PostTipoPix(TipoPix tipoPix)
        {
          if (_context.TipoPix == null)
          {
              return Problem("Entity set 'ProjAPICarroContext.TipoPix'  is null.");
          }
            _context.TipoPix.Add(tipoPix);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoPix", new { id = tipoPix.Id }, tipoPix);
        }

        // DELETE: api/TiposPix/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoPix(int id)
        {
            if (_context.TipoPix == null)
            {
                return NotFound();
            }
            var tipoPix = await _context.TipoPix.FindAsync(id);
            if (tipoPix == null)
            {
                return NotFound();
            }

            _context.TipoPix.Remove(tipoPix);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoPixExists(int id)
        {
            return (_context.TipoPix?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
