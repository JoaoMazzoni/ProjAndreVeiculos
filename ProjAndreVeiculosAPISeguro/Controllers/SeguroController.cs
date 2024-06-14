using Microsoft.AspNetCore.Mvc;
using Models;
using ProjAndreVeiculosAPISeguro.Services;

namespace ProjAndreVeiculosAPISeguro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguroController : Controller
    {
        private SeguroService seguroService;
        public SeguroController()
        {
            seguroService = new SeguroService();
        }

        [HttpGet]
        public ActionResult<List<Seguro>> GetAllSeguro()
        {
           
            return seguroService.GetAllSeguro();
        }

        
        [HttpPost]
        public bool PostSeguro(Seguro seguro)
        {
            return seguroService.PostSeguro(seguro);
        }
    }
}
