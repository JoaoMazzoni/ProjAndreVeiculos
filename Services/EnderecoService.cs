using Repositories;

namespace Services
{
    public class EnderecoService
    {
        private EnderecoRepository enderecoRepository;

        public EnderecoService()
        {
            enderecoRepository = new EnderecoRepository();
        }

        public void InsertEndereco()
        {
            enderecoRepository.InsertEndereco();
        }

    }
}
