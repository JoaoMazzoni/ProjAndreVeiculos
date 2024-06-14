using Models;
using ProjAndreVeiculosAPIFinanciamento.Repositories;

namespace ProjAndreVeiculosAPIFinanciamento.Services
{
    public class FinanciamentoService
    {

        private FinanciamentoRepository financiamentoRepository;
        

        public FinanciamentoService()
        {
            financiamentoRepository = new FinanciamentoRepository();
           
        }

        public bool Inserir(Financiamento financiamento)
        {
            int idItem = itemRepository.Inserir(pedido.Item);
            pedido.Item.ItemId = idItem;
            return pedidoRepository.Inserir(pedido);

        }

        public List<Pedido> GetAll()
        {
            return pedidoRepository.GetAll();
        }

    }
}
