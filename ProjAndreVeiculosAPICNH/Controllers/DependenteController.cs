using Microsoft.AspNetCore.Mvc;
using Models;
using ProjAndreVeiculosAPIDependente.Services;

namespace ProjAndreVeiculosAPIDependente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DependenteController : ControllerBase
    {
        private readonly DependenteService _dependenteService;

        public DependenteController(DependenteService dependenteService)
        {
            _dependenteService = dependenteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dependente>>> GetDependentes()
        {
            var dependentes = await _dependenteService.GetAll();
            return Ok(dependentes);
        }

        [HttpGet("{documento}")]
        public async Task<ActionResult<Dependente>> GetDependente(string documento)
        {
            var dependente = await _dependenteService.GetById(documento);
            if (dependente == null)
            {
                return NotFound();
            }
            return Ok(dependente);
        }

        [HttpPost]
        public async Task<ActionResult> PostDependente(Dependente dependente)
        {
            await _dependenteService.Add(dependente);
            return CreatedAtAction(nameof(GetDependente), new { document = dependente.Documento }, dependente);
        }

        [HttpPut("{documento}")]
        public async Task<IActionResult> PutDependente(string documento, Dependente dependente)
        {
            if (documento != dependente.Documento)
            {
                return BadRequest();
            }
            await _dependenteService.Update(dependente);
            return NoContent();
        }

        [HttpDelete("{documento}")]
        public async Task<IActionResult> DeleteDependente(string documento)
        {
            await _dependenteService.Delete(documento);
            return NoContent();
        }
    }
}
