using Models;
using ProjAndreVeiculosAPISeguro.Repositories;

namespace ProjAndreVeiculosAPISeguro.Services
{
    public class SeguroService
    {
        private SeguroRepository seguroRepository;

        public SeguroService()
        {
            seguroRepository = new SeguroRepository();
        }

        public bool PostSeguro(Seguro seguro)
        {
           
            return seguroRepository.PostSeguro(seguro);

        }

        public List<Seguro> GetAllSeguro()
        {
            return seguroRepository.GetAll();
        }
    }
}
