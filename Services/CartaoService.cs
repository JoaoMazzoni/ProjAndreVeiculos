using Repositories;

namespace Services
{
    public class CartaoService
    {
        CartaoRepository cartaoRepository;

        public CartaoService()
        {
            cartaoRepository = new CartaoRepository();
        }

        public void InsertCartao()
        {
            cartaoRepository.InsertCartao();
        }


    }
}
