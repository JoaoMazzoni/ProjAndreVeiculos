using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using ProjAndreVeiculosAPICondutor.Data;

namespace ProjAndreVeiculosAPICondutor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CNHsController : ControllerBase
    {
        private readonly ProjAndreVeiculosAPICondutorContext _context;

        public CNHsController(ProjAndreVeiculosAPICondutorContext context)
        {
            _context = context;
        }

        // GET: api/CNHs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CNH>>> GetCNH()
        {
          if (_context.CNH == null)
          {
              return NotFound();
          }
            return await _context.CNH.ToListAsync();
        }

        // GET: api/CNHs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CNH>> GetCNH(long id)
        {
          if (_context.CNH == null)
          {
              return NotFound();
          }
            var cNH = await _context.CNH.FindAsync(id);

            if (cNH == null)
            {
                return NotFound();
            }

            return cNH;
        }

        // PUT: api/CNHs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCNH(long id, CNH cNH)
        {
            if (id != cNH.CNHNumero)
            {
                return BadRequest();
            }

            _context.Entry(cNH).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CNHExists(id))
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

        // POST: api/CNHs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CNH>> PostCNH(CNH cNH)
        {
          if (_context.CNH == null)
          {
              return Problem("Entity set 'ProjAndreVeiculosAPICondutorContext.CNH'  is null.");
          }
            _context.CNH.Add(cNH);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCNH", new { id = cNH.CNHNumero }, cNH);
        }

        // DELETE: api/CNHs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCNH(long id)
        {
            if (_context.CNH == null)
            {
                return NotFound();
            }
            var cNH = await _context.CNH.FindAsync(id);
            if (cNH == null)
            {
                return NotFound();
            }

            _context.CNH.Remove(cNH);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CNHExists(long id)
        {
            return (_context.CNH?.Any(e => e.CNHNumero == id)).GetValueOrDefault();
        }
    }
}
