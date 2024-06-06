using Repositories;

namespace Services
{
    public class ClienteService
    {
        private ClienteRepository clienteRepository;

        public ClienteService()
        {
            clienteRepository = new ClienteRepository();
        }

        public void InsertCliente()
        {
            clienteRepository.InsertCliente();
        }

    }
}
