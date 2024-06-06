using Repositories;

namespace Services
{
    public class BoletoService
    {
        private BoletoRepository boletoRepository;

        public BoletoService()
        {
            boletoRepository = new BoletoRepository();
        }

        public void InsertBoleto()
        {
            boletoRepository.InsertBoleto();
        }


    }
}
