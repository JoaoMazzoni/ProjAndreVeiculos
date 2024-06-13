using Microsoft.AspNetCore.Mvc;
using Models;
using ProjAndreVeiculosAPITermoUso.Services;

namespace ProjAndreVeiculosAPITermoUso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermoUsoController : Controller
    {
        private readonly TermoUsoService _termoService;

        public TermoUsoController(TermoUsoService termoService)
        {
            _termoService = termoService;
        }

        [HttpGet]
        public ActionResult<List<TermoDeUso>> GetTermos()
        {
            return _termoService.GetTermos();
        }

        [HttpPost]
        public ActionResult<TermoDeUso> PostBank(TermoDeUso termo)
        {
            _termoService.Create(termo);
            return Ok(termo);
        }
    }
}
