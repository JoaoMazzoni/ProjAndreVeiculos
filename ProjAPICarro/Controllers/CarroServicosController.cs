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
    public class CarroServicosController : ControllerBase
    {
        private readonly ProjAPICarroContext _context;

        public CarroServicosController(ProjAPICarroContext context)
        {
            _context = context;
        }

        // GET: api/CarroServicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarroServico>>> GetCarroServico()
        {
          if (_context.CarroServico == null)
          {
              return NotFound();
          }
            return await _context.CarroServico.Include(c => c.Carro).Include(s => s.Servico).ToListAsync();
        }

        // GET: api/CarroServicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarroServico>> GetCarroServico(int id)
        {
          if (_context.CarroServico == null)
          {
              return NotFound();
          }
            var carroServico = await _context.CarroServico.Include(c => c.Carro).Include(s => s.Servico).Where(cs => cs.Id == id).FirstOrDefaultAsync();

            if (carroServico == null)
            {
                return NotFound();
            }

            return carroServico;
        }

        // PUT: api/CarroServicos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarroServico(int id, CarroServico carroServico)
        {
            if (id != carroServico.Id)
            {
                return BadRequest();
            }

            _context.Entry(carroServico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarroServicoExists(id))
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

        // POST: api/CarroServicos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarroServico>> PostCarroServico(CarroServico carroServico)
        {
          if (_context.CarroServico == null)
          {
              return Problem("Entity set 'ProjAPICarroContext.CarroServico'  is null.");
          }
            _context.CarroServico.Add(carroServico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarroServico", new { id = carroServico.Id }, carroServico);
        }

        // DELETE: api/CarroServicos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarroServico(int id)
        {
            if (_context.CarroServico == null)
            {
                return NotFound();
            }
            var carroServico = await _context.CarroServico.FindAsync(id);
            if (carroServico == null)
            {
                return NotFound();
            }

            _context.CarroServico.Remove(carroServico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarroServicoExists(int id)
        {
            return (_context.CarroServico?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
