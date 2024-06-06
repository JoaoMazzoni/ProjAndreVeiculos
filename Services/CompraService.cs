using Repositories;

namespace Services
{
    public class CompraService
    {
        private CompraRepository compraRepository;

        public CompraService()
        {
            compraRepository = new CompraRepository();
        }

        public void InsertCompra()
        {
            compraRepository.InsertCompra();
        }


    }
}
